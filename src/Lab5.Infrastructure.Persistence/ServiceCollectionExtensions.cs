using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        collection.AddSingleton<IAccountRepository, AccountRepository>();
        collection.AddSingleton<IUserSessionRepository, UserSessionRepository>();
        collection.AddSingleton<IAdminSessionRepository, AdminSessionRepository>();
        collection.AddSingleton<IOperationHistoryRepository, OperationHistoryRepository>();
        return collection;
    }
}
