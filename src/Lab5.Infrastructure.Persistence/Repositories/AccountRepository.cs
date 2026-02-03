using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Accounts;

namespace Lab5.Infrastructure.Persistence.Repositories;

public sealed class AccountRepository : IAccountRepository
{
    private readonly Dictionary<string, Account> _values = [];

    public void Add(Account account)
    {
        _values.Add(account.AccountNumber, account);
    }

    public void Update(Account account)
    {
        if (_values.ContainsKey(account.AccountNumber) is false)
            throw new InvalidOperationException("Order not found");

        _values[account.AccountNumber] = account;
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        return _values.Values
            .Where(x => query.AccountNumber is [] || query.AccountNumber.Contains(x.AccountNumber));
    }
}