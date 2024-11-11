using EmployCheck.Application.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployCheck.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString  = configuration["DefaultConnection:SqlLite"];
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=app.db"));
        services.AddScoped<IEmployCheckRepository, EmployCheckRepository>();
        return services;
    }
}