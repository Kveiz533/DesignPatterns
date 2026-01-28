using Lab5.Application.Contracts.Accounts.Models;

namespace Lab5.Application.Contracts.Accounts.Operations;

public static class OperationHistory
{
    public readonly record struct Request(Guid SessionId);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(OperationHistoryDto History) : Response;

        public sealed record Failure(string Message) : Response;
    }
}