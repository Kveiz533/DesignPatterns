using Lab5.Application.Contracts.Admins.Models;

namespace Lab5.Application.Contracts.Admins.Operations;

public static class CreateAccount
{
    public readonly record struct Request(Guid SessionId, string AccountNumber, string PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AdminDto Session) : Response;

        public sealed record Failure(string Message) : Response;
    }
}