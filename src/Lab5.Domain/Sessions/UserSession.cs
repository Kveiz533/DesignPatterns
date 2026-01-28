namespace Lab5.Domain.Sessions;

public sealed class UserSession
{
    public UserSession(Guid sessionId, string accountNumber)
    {
        SessionId = sessionId;
        AccountNumber = accountNumber;
    }

    public Guid SessionId { get; }

    public string AccountNumber { get; }
}
