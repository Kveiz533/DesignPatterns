using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserSessionRepository
{
    void Add(Session session);

    IEnumerable<Session> Query(SessionQuery query);
}