using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Mapping;

public static class UserSessionMappingExtension
{
    public static SessionDto MapToDto(this UserSession userSession)
    {
        return new SessionDto(userSession.SessionId);
    }
}
