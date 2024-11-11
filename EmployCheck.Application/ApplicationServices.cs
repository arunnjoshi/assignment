using EmployCheck.Application.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EmployCheck.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployCheckRepository, EmployCheckRepository>();
        return services;
    }
}