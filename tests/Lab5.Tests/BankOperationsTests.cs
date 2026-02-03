using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Services;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;
using Lab5.Infrastructure.Persistence;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankOperationsTests
{
    private const string AccountNumber = "11111111111111111111";
    private const string PinCode = "1234";
    private const decimal Amount = 100m;

    [Fact]
    public void BankOperationTests_DepositMoneyAndBalanceChanged_Success()
    {
        // Arrange
        IAccountRepository mockAccountRepository = Substitute.For<IAccountRepository>();
        IAdminSessionRepository mockAdminSessionRepository = Substitute.For<IAdminSessionRepository>();
        IOperationHistoryRepository mockOperationHistoryRepository = Substitute.For<IOperationHistoryRepository>();
        IUserSessionRepository mockUserSessionRepository = Substitute.For<IUserSessionRepository>();

        var persistenceContext = new PersistenceContext(
            mockAccountRepository,
            mockUserSessionRepository,
            mockAdminSessionRepository,
            mockOperationHistoryRepository);

        var accountService = new AccountService(persistenceContext);

        var expectedBalance = new Money(100m);
        var sessionId = Guid.NewGuid();

        var account = new Account(AccountNumber, PinCode);

        mockUserSessionRepository
            .Query(Arg.Any<SessionQuery>())
            .Returns([new UserSession(sessionId, AccountNumber)]);
        mockAccountRepository
            .Query(Arg.Any<AccountQuery>())
            .Returns([account]);

        // Act
        accountService.Deposit(new Deposit.Request(sessionId, Amount));

        // Assert
        mockAccountRepository.Received(1).Update(Arg.Is<Account>(a =>
            a.AccountNumber == AccountNumber &&
            a.Balance == expectedBalance));
    }

    [Fact]
    public void BankOperationTests_WithdrawLessThanBalance_Success()
    {
        // Arrange
        IAccountRepository mockAccountRepository = Substitute.For<IAccountRepository>();
        IAdminSessionRepository mockAdminSessionRepository = Substitute.For<IAdminSessionRepository>();
        IOperationHistoryRepository mockOperationHistoryRepository = Substitute.For<IOperationHistoryRepository>();
        IUserSessionRepository mockUserSessionRepository = Substitute.For<IUserSessionRepository>();

        var persistenceContext = new PersistenceContext(
            mockAccountRepository,
            mockUserSessionRepository,
            mockAdminSessionRepository,
            mockOperationHistoryRepository);

        var accountService = new AccountService(persistenceContext);

        var expectedBalance = new Money(0m);
        var sessionId = Guid.NewGuid();

        var account = new Account(AccountNumber, PinCode);

        mockUserSessionRepository
            .Query(Arg.Any<SessionQuery>())
            .Returns([new UserSession(sessionId, AccountNumber)]);
        mockAccountRepository
            .Query(Arg.Any<AccountQuery>())
            .Returns([account]);

        // Act
        account.Deposit(new Money(Amount));
        accountService.Withdraw(new Withdraw.Request(sessionId, Amount));

        // Assert
        mockAccountRepository.Received(1).Update(Arg.Is<Account>(a =>
            a.AccountNumber == AccountNumber &&
            a.Balance == expectedBalance));
    }

    [Fact]
    public void BankOperationTests_WithdrawMoreThanBalance_Failed()
    {
        // Arrange
        IAccountRepository mockAccountRepository = Substitute.For<IAccountRepository>();
        IAdminSessionRepository mockAdminSessionRepository = Substitute.For<IAdminSessionRepository>();
        IOperationHistoryRepository mockOperationHistoryRepository = Substitute.For<IOperationHistoryRepository>();
        IUserSessionRepository mockUserSessionRepository = Substitute.For<IUserSessionRepository>();

        var persistenceContext = new PersistenceContext(
            mockAccountRepository,
            mockUserSessionRepository,
            mockAdminSessionRepository,
            mockOperationHistoryRepository);

        var accountService = new AccountService(persistenceContext);

        var sessionId = Guid.NewGuid();

        var account = new Account(AccountNumber, PinCode);

        mockUserSessionRepository
            .Query(Arg.Any<SessionQuery>())
            .Returns([new UserSession(sessionId, AccountNumber)]);
        mockAccountRepository
            .Query(Arg.Any<AccountQuery>())
            .Returns([account]);

        // Act
        account.Deposit(new Money(Amount - 1m));
        accountService.Withdraw(new Withdraw.Request(sessionId, Amount));

        // Assert
        mockAccountRepository.DidNotReceive().Update(Arg.Any<Account>());
    }
}