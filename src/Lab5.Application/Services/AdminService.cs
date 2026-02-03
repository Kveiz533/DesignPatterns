using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Contracts.Admins;
using Lab5.Application.Contracts.Admins.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Services;

public sealed class AdminService : IAdminService
{
    private readonly IPersistenceContext _context;

    public AdminService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        string accountNumber = request.AccountNumber;
        string pinCode = request.PinCode;
        Guid sessionId = request.SessionId;

        AdminSession? session = _context.AdminSessionRepository
            .Query(SessionQuery.Build(builder => builder.WithSessionId(sessionId)))
            .SingleOrDefault();

        if (session is null)
        {
            return new CreateAccount.Response.Failure("Session not found");
        }

        Account? account = _context.AccountRepository
            .Query(AccountQuery.Build(builder => builder.WithAccountNumber(accountNumber)))
            .SingleOrDefault();

        if (account is not null)
        {
            return new CreateAccount.Response.Failure("Account already exists");
        }

        var newAccount = new Account(accountNumber, pinCode);
        _context.AccountRepository.Add(newAccount);

        return new CreateAccount.Response.Success(newAccount.MapToDto());
    }
}