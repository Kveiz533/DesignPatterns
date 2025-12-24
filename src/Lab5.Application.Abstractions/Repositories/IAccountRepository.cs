using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    void Add(Account account);

    void Update(Account account);

    IEnumerable<Account> Query(AccountQuery query);
}