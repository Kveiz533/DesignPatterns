using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

public sealed class AdminSessionRepository : IAdminSessionRepository
{
    private readonly Dictionary<Guid, Session> _values = [];

    public void Add(Session session)
    {
        _values.Add(session.SessionId, session);
    }

    public IEnumerable<Session> Query(SessionQuery query)
    {
        return _values.Values
            .Where(x => query.SessionId is [] || query.SessionId.Contains(x.SessionId));
    }
}