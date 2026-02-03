using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

public sealed class UserSessionRepository : IUserSessionRepository
{
    private readonly Dictionary<Guid, UserSession> _values = [];

    public void Add(UserSession userSession)
    {
        _values.Add(userSession.SessionId, userSession);
    }

    public IEnumerable<UserSession> Query(SessionQuery query)
    {
        return _values.Values
            .Where(x => query.SessionId is [] || query.SessionId.Contains(x.SessionId));
    }
}