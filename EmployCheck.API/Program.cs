using EmployCheck.API.Validations.Employment;
using EmployCheck.Contracts.Employment.Requests;
using EmployCheck.Application;
using EmployCheck.Application.Models;
using EmployCheck.Application.Repository;
using EmployCheck.Application.UnitOfWork;
using EmployCheck.Contracts.Employment.Responses;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.ImplicitlyValidateChildProperties = true;
        fv.ImplicitlyValidateRootCollectionElements = true;
        fv.RegisterValidatorsFromAssemblyContaining<VerifyEmployment>();
    });
;
builder.Services.AddApplicationServices(configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

//Endpoint
app.MapPost("/api/verify-employment",
        async (VerifyEmploymentRequest request,
            IUnitOfWork unitOfWork,
            IValidator<VerifyEmploymentRequest> validator) =>
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            if (await unitOfWork.EmployCheckRepository.IsEmploymentVerified(request.EmployeeId))
            {
                return Results.BadRequest(new VerifyEmploymentResponse
                    { IsEmploymentVerified = false, Message = "Employment verified already" });
            }

            if (!await unitOfWork.EmployCheckRepository.VerifyEmployment(new Employment
                {
                    EmployeeId = request.EmployeeId,
                    VerificationCode = request.VerificationCode,
                    IsEmploymentVerified = false
                }))
            {
                return Results.BadRequest(new VerifyEmploymentResponse
                    { IsEmploymentVerified = false, Message = "Please enter a valid details" });
            }
            await unitOfWork.CompleteAsync();
            return Results.Ok(new VerifyEmploymentResponse
                { IsEmploymentVerified = true, Message = "Verified" });
        })
    .WithName("verify-employment")
    .WithOpenApi();

// Seeding
using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
    await dbInitializer.InitializeAsync();
}
app.Run();