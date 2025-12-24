using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserSessionRepository
{
    void Add(UserSession userSession);

    IEnumerable<UserSession> Query(SessionQuery query);
}