using ChildCentre.Slynchogled.Data.Models;

namespace ChildCentre.Slynchogled.Services.Interfaces
{
    public interface IClientsService
    {
        void RegisterAccount(Account account);

        List<Account> GetAccounts();

        Account GetAccount(int accountId);

        void SaveParent(Parent parent);

        Parent GetParent(int id);

        void SaveChild(Child child);

        Child GetChild(int id);
    }
}