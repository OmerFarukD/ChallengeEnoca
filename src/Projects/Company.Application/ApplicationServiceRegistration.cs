using System.Reflection;
using Company.Application.Features.Order.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this  IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<OrderBusinessRules>();
        
        return services;
        
    }
}