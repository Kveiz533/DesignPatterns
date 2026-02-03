using Lab5.Application.Abstractions.Repositories;

namespace Lab5.Application.Abstractions;

public interface IPersistenceContext
{
    IAccountRepository AccountRepository { get; }

    IUserSessionRepository UserSessionRepository { get; }

    IAdminSessionRepository AdminSessionRepository { get; }

    IOperationHistoryRepository OperationHistoryRepository { get; }
}