using Lab5.Application.Contracts.Sessions.Operations;

namespace Lab5.Application.Contracts.Sessions;

public interface ISessionService
{
    LogInUser.Response LogInUser(LogInUser.Request request);

    LogInAdmin.Response LogInAdmin(LogInAdmin.Request request);
}