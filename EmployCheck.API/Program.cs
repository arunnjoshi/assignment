using EmployCheck.API.Validations.Employment;
using EmployCheck.Contracts.Employment.Requests;
using EmployCheck.Application;
using EmployCheck.Application.Models;
using EmployCheck.Application.Repository;
using EmployCheck.Contracts.Employment.Responses;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddApplicationServices(configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/verify-employment",
        async (VerifyEmploymentRequest request,
            IEmployCheckRepository employCheckRepository,
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

            if (await employCheckRepository.IsEmploymentVerified(request.EmployeeId))
            {
                return Results.BadRequest(new VerifyEmploymentResponse
                    { IsEmploymentVerified = false, Message = "Employment verified already" });
            }

            if (await employCheckRepository.VerifyEmployment(new Employment()))
            {
                return Results.Ok(new VerifyEmploymentResponse
                    { IsEmploymentVerified = true, Message = "Verified" });
            }

            return Results.BadRequest(new VerifyEmploymentResponse
                { IsEmploymentVerified = false, Message = "Please enter a valid details" });
        })
    .WithName("verify-employment")
    .WithOpenApi();

app.Run();