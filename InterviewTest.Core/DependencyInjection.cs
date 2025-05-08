using InterviewTest.Core.Mappers;
using InterviewTest.Core.ServiceContracts;
using InterviewTest.Core.Services;
using Microsoft.Extensions.DependencyInjection;


namespace InterviewTest.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EmployeeToEmployeeResponseMappingProfile).Assembly);

        services.AddScoped<IEmployeeService, EmployeeService>();

        return services;
    }
}