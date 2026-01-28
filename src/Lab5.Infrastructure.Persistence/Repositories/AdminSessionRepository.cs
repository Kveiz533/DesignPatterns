using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

public sealed class AdminSessionRepository : IAdminSessionRepository
{
    private readonly Dictionary<Guid, AdminSession> _values = [];

    public void Add(AdminSession adminSession)
    {
        _values.Add(adminSession.SessionId, adminSession);
    }

    public IEnumerable<AdminSession> Query(SessionQuery query)
    {
        return _values.Values
            .Where(x => query.SessionId is [] || query.SessionId.Contains(x.SessionId));
    }
}