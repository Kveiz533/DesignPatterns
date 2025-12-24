using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;
using Microsoft.Extensions.Configuration;

namespace Lab5.Application.Services;

public sealed class SessionService : ISessionService
{
    private readonly string _systemPassword;
    private readonly IPersistenceContext _context;

    public SessionService(IPersistenceContext context, IConfiguration configuration)
    {
        _systemPassword = configuration["AdminSettings:SystemPassword"]
                          ?? throw new InvalidOperationException("Password not found in config");
        _context = context;
    }

    public LogInUser.Response LogInUser(LogInUser.Request request)
    {
        string accountNumber = request.AccountNumber;

        Account? account = _context.AccountRepository
            .Query(AccountQuery.Build(builder => builder.WithAccountNumber(accountNumber)))
            .SingleOrDefault();

        if (account is null)
        {
            return new LogInUser.Response.Failure("Account not found");
        }

        if (!account.VerifyPinCode(request.PinCode))
        {
            return new LogInUser.Response.Failure("Invalid pin code");
        }

        var sessionId = Guid.NewGuid();
        var session = new Session(sessionId, account.AccountNumber);
        _context.UserSessionRepository.Add(session);

        return new LogInUser.Response.Success(session.MapToDto());
    }

    public LogInAdmin.Response LogInAdmin(LogInAdmin.Request request)
    {
        string systemPassword = request.SystemPassword;

        if (systemPassword != _systemPassword)
        {
            return new LogInAdmin.Response.Failure("Invalid password");
        }

        var sessionId = Guid.NewGuid();
        var session = new Session(sessionId, "Admin");
        _context.AdminSessionRepository.Add(session);

        return new LogInAdmin.Response.Success(session.MapToDto());
    }
}