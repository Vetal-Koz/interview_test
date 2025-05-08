using InterviewTest.Core.RepositoryContracts;
using InterviewTest.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewTest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        
        return services;
    }
}