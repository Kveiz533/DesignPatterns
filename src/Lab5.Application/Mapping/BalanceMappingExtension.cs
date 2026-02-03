using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Mapping;

public static class BalanceMappingExtension
{
    public static BalanceDto MapToDto(this Money money)
    {
        return new BalanceDto(money.Value);
    }
}