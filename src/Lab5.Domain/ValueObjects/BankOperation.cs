namespace Lab5.Domain.ValueObjects;

public sealed record BankOperation
{
    public BankOperation(string accountNumber, string name, Money newBalance)
    {
        AccountNumber = accountNumber;
        Name = name;
        NewBalance = newBalance;
        Time = DateTimeOffset.UtcNow;
    }

    public string AccountNumber { get; }

    public DateTimeOffset Time { get; }

    public string Name { get; }

    public Money NewBalance { get; }
}