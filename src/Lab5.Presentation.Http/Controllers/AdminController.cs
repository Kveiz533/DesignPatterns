using Lab5.Application.Contracts.Admins;
using Lab5.Application.Contracts.Admins.Operations;
using Lab5.Application.Contracts.Sessions.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("/api/admin")]
public sealed class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("accounts")]
    public ActionResult<SessionDto> CreateAccount(Guid sessionId, string accountNumber, string pinCode)
    {
        var request = new CreateAccount.Request(sessionId, accountNumber, pinCode);
        CreateAccount.Response response = _adminService.CreateAccount(request);
        return response switch
        {
            CreateAccount.Response.Success success => Ok(success.Session),
            CreateAccount.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}