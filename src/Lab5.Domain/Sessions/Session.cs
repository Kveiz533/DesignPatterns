namespace Lab5.Domain.Sessions;

public sealed class Session
{
    public Session(Guid sessionId, string accountNumber)
    {
        SessionId = sessionId;
        AccountNumber = accountNumber;
    }

    public Guid SessionId { get; }

    public string AccountNumber { get; }
}
