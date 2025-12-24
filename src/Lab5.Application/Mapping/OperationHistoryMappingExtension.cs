using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Mapping;

public static class OperationHistoryMappingExtension
{
    public static OperationHistoryDto MapToDto(this IEnumerable<BankOperation> bankOperations)
    {
        return new OperationHistoryDto(bankOperations
            .Select(op => $"[{op.Time}] Account: {op.AccountNumber} | {op.Name} | Balance: {op.NewBalance.Value}")
            .ToArray());
    }
}
