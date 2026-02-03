using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("/api/session")]
public sealed class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("admin")]
    public ActionResult<SessionDto> LogInAdmin([FromBody] LogInAdminRequest httpRequest)
    {
        var request = new LogInAdmin.Request(httpRequest.SystemPassword);
        LogInAdmin.Response response = _sessionService.LogInAdmin(request);

        return response switch
        {
            LogInAdmin.Response.Success success => Ok(success.Session),
            LogInAdmin.Response.Failure failure => Unauthorized(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("user")]
    public ActionResult<SessionDto> LogInUser([FromBody] LogInUserRequest httpRequest)
    {
        var request = new LogInUser.Request(httpRequest.AccountNumber, httpRequest.PinCode);
        LogInUser.Response response = _sessionService.LogInUser(request);

        return response switch
        {
            LogInUser.Response.Success success => Ok(success.Session),
            LogInUser.Response.Failure failure => Unauthorized(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}