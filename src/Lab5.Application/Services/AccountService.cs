using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.Accounts.Results;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

public sealed class AccountService : IAccountService
{
    private readonly IPersistenceContext _context;

    public AccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public Balance.Response Balance(Balance.Request request)
    {
        Guid sessionId = request.SessionId;

        UserSession? session = _context.UserSessionRepository
            .Query(SessionQuery.Build(builder => builder.WithSessionId(sessionId)))
            .SingleOrDefault();

        if (session is null)
        {
            return new Balance.Response.Failure("Session not found");
        }

        string accountNumber = session.AccountNumber;

        Account? account = _context.AccountRepository
            .Query(AccountQuery.Build(builder => builder.WithAccountNumber(accountNumber)))
            .SingleOrDefault();

        if (account is null)
        {
            return new Balance.Response.Failure("Account not found");
        }

        var bankOperation = new BankOperation(accountNumber, "balance", account.Balance);
        _context.OperationHistoryRepository.Add(bankOperation);

        return new Balance.Response.Success(account.Balance.MapToDto());
    }

    public Deposit.Response Deposit(Deposit.Request request)
    {
        Guid sessionId = request.SessionId;
        decimal balance = request.Amount;

        UserSession? session = _context.UserSessionRepository
            .Query(SessionQuery.Build(builder => builder.WithSessionId(sessionId)))
            .SingleOrDefault();

        if (session is null)
        {
            return new Deposit.Response.Failure("Session not found");
        }

        string accountNumber = session.AccountNumber;

        Account? account = _context.AccountRepository
            .Query(AccountQuery.Build(builder => builder.WithAccountNumber(accountNumber)))
            .SingleOrDefault();

        if (account is null)
        {
            return new Deposit.Response.Failure("Account not found");
        }

        account.Deposit(new Money(balance));
        _context.AccountRepository.Update(account);

        var bankOperation = new BankOperation(accountNumber, "deposit", account.Balance);
        _context.OperationHistoryRepository.Add(bankOperation);

        return new Deposit.Response.Success(account.Balance.MapToDto());
    }

    public Withdraw.Response Withdraw(Withdraw.Request request)
    {
        Guid sessionId = request.SessionId;
        decimal balance = request.Amount;

        UserSession? session = _context.UserSessionRepository
            .Query(SessionQuery.Build(builder => builder.WithSessionId(sessionId)))
            .SingleOrDefault();

        if (session is null)
        {
            return new Withdraw.Response.Failure("Session not found");
        }

        string accountNumber = session.AccountNumber;

        Account? account = _context.AccountRepository
            .Query(AccountQuery.Build(builder => builder.WithAccountNumber(accountNumber)))
            .SingleOrDefault();

        if (account is null)
        {
            return new Withdraw.Response.Failure("Account not found");
        }

        WithdrawResult withdrawResult = account.Withdraw(new Money(balance));

        if (withdrawResult is WithdrawResult.Failure)
        {
            return new Withdraw.Response.Failure("Operation failed");
        }

        _context.AccountRepository.Update(account);
        var bankOperation = new BankOperation(accountNumber, "withdraw", account.Balance);
        _context.OperationHistoryRepository.Add(bankOperation);

        return new Withdraw.Response.Success(account.Balance.MapToDto());
    }

    public OperationHistory.Response OperationHistory(OperationHistory.Request request)
    {
        Guid sessionId = request.SessionId;

        UserSession? session = _context.UserSessionRepository
            .Query(SessionQuery.Build(builder => builder.WithSessionId(sessionId)))
            .SingleOrDefault();

        if (session is null)
        {
            return new OperationHistory.Response.Failure("Session not found");
        }

        string accountNumber = session.AccountNumber;

        var history = _context.OperationHistoryRepository
            .Query(OperationHistoryQuery.Build(builder => builder.WithAccountNumber(accountNumber)))
            .ToList();

        return history.Count > 0
            ? new OperationHistory.Response.Success(history.MapToDto())
            : new OperationHistory.Response.Failure("Operation failed");
    }
}