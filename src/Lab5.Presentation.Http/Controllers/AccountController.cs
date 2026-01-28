using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Accounts.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("/api/account")]
public sealed class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("balance")]
    public ActionResult<BalanceDto> Balance(Guid sessionId)
    {
        var request = new Balance.Request(sessionId);
        Balance.Response response = _accountService.Balance(request);
        return response switch
        {
            Balance.Response.Success success => Ok(success.Balance),
            Balance.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("deposit")]
    public ActionResult<BalanceDto> Deposit(Guid sessionId, decimal money)
    {
        var request = new Deposit.Request(sessionId, money);
        Deposit.Response response = _accountService.Deposit(request);
        return response switch
        {
            Deposit.Response.Success success => Ok(success.NewBalance),
            Deposit.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withdraw")]
    public ActionResult<BalanceDto> Withdraw(Guid sessionId, decimal money)
    {
        var request = new Withdraw.Request(sessionId, money);
        Withdraw.Response response = _accountService.Withdraw(request);
        return response switch
        {
            Withdraw.Response.Success success => Ok(success.NewBalance),
            Withdraw.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpGet("history")]
    public ActionResult ShowHistory(Guid sessionId)
    {
        var request = new OperationHistory.Request(sessionId);
        OperationHistory.Response response = _accountService.OperationHistory(request);
        return response switch
        {
            OperationHistory.Response.Success success => Ok(success.History),
            OperationHistory.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}