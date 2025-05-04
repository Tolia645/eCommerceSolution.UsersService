using Microsoft.Extensions.DependencyInjection;
using eCommerce.Core.Services;
using eCommerce.Core.Interfaces;
using FluentValidation;
using eCommerce.Core.Validators;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IUsersService, UsersService>();
        
        return services;
    }
}