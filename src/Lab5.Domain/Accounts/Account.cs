using Lab5.Domain.Accounts.Results;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Accounts;

public class Account
{
    private readonly string _pinCode;

    public string AccountNumber { get; }

    public Money Balance { get; private set; } = Money.Zero();

    public Account(string accountNumber, string pinCode)
    {
        AccountNumber = accountNumber;
        _pinCode = pinCode;
    }

    public bool VerifyPinCode(string pinCode)
    {
        return _pinCode == pinCode;
    }

    public void Deposit(Money amount)
    {
        Balance += amount;
    }

    public WithdrawResult Withdraw(Money amount)
    {
        if (amount > Balance)
        {
            return new WithdrawResult.Failure("Insufficient funds");
        }

        Balance -= amount;
        return new WithdrawResult.Success();
    }
}