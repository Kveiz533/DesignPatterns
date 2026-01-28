using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<ISessionService, SessionService>();
        collection.AddScoped<IAccountService, AccountService>();

        return collection;
    }
}
