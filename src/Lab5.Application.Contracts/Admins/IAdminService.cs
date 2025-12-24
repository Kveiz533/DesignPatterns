using Lab5.Application.Contracts.Admins.Operations;

namespace Lab5.Application.Contracts.Admins;

public interface IAdminService
{
    CreateAccount.Response CreateAccount(CreateAccount.Request request);
}