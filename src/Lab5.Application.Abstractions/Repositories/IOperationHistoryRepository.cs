using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationHistoryRepository
{
    void Add(BankOperation bankOperation);

    IEnumerable<BankOperation> Query(OperationHistoryQuery query);
}