using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Mapping;

public static class AdminSessionMappingExtension
{
    public static SessionDto MapToDto(this AdminSession adminSession)
    {
        return new SessionDto(adminSession.SessionId);
    }
}