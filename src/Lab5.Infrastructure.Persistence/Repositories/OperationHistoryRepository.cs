using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.ValueObjects;

namespace Lab5.Infrastructure.Persistence.Repositories;

public sealed class OperationHistoryRepository : IOperationHistoryRepository
{
    private readonly Dictionary<string, List<BankOperation>> _values = [];

    public void Add(BankOperation bankOperation)
    {
        if (!_values.TryGetValue(bankOperation.AccountNumber, out List<BankOperation>? history))
        {
            history = [];
            _values[bankOperation.AccountNumber] = history;
        }

        history.Add(bankOperation);
    }

    public IEnumerable<BankOperation> Query(OperationHistoryQuery query)
    {
        return query.AccountNumber
            .SelectMany(acc => _values.TryGetValue(acc, out List<BankOperation>? operations)
                ? operations
                : []);
    }
}