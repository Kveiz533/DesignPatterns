namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates;

public abstract record SessionStateResult
{
    private SessionStateResult() { }

    public sealed record Success(ISessionState SessionState) : SessionStateResult;

    public sealed record Failure(string Message) : SessionStateResult;
}