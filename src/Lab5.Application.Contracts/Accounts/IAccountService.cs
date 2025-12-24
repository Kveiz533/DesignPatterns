using Lab5.Application.Contracts.Accounts.Operations;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    Balance.Response Balance(Balance.Request request);

    Deposit.Response Deposit(Deposit.Request request);

    Withdraw.Response Withdraw(Withdraw.Request request);

    OperationHistory.Response OperationHistory(OperationHistory.Request request);
}