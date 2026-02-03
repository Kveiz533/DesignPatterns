using Lab5.Application.Contracts.Admins.Models;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Mapping;

public static class AccountMappingExtension
{
    public static AdminDto MapToDto(this Account account)
    {
        return new AdminDto(account.AccountNumber);
    }
}