using ChildCentre.Slynchogled.Data.Context;
using ChildCentre.Slynchogled.Data.Models;
using ChildCentre.Slynchogled.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChildCentre.Slynchogled.Services.Services
{
    public class ClientsService : IClientsService
    {
        private readonly ChildCentreContext _dbContext;

        public ClientsService(ChildCentreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RegisterAccount(Account account)
        {
            Account duplicate = _dbContext.Accounts.FirstOrDefault(a => a.PhoneNumber == account.PhoneNumber);

            if (duplicate != null)
                throw new Exception($"Вече съществува регистрация с тел. номер {account.PhoneNumber} (Име на регистрацията: {duplicate.Name}).");

            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

        public List<Account> GetAccounts()
        {
            return _dbContext.Accounts
                .Include(a => a.Parents)
                .Include(a => a.Children)
                .ToList();
        }

        public Account GetAccount(int accountId)
        {
            return _dbContext.Accounts
                .Include(a => a.Parents)
                .Include(a => a.Children)
                .First(a => a.Id == accountId);
        }

        public void SaveParent(Parent parent)
        {
            if (parent.AccountId == 0)
                throw new Exception($"Неуспешно запазване на родител. Родителят не е свързан със същесвуваща регистрация.");

            if (parent.ID == 0)
            {
                Account account = _dbContext.Accounts.First(a => a.Id == parent.AccountId);

                if (account.Parents.Any(p => p.PhoneNumber == parent.PhoneNumber))
                    throw new Exception($"Вече съществува родител с тел. номер {parent.PhoneNumber}.");

                _dbContext.Parents.Add(parent);
            }
            else
            {
                Parent currentParent = _dbContext.Parents.First(p => p.ID == parent.ID);

                if (currentParent.AccountId != parent.AccountId)
                    throw new Exception($"Неуспешно запазване на родител. Смяна на регистрацията на родител не е позволена.");

                currentParent.FirstName = parent.FirstName;
                currentParent.MiddleName = parent.MiddleName;
                currentParent.LastName = parent.LastName;
                currentParent.PhoneNumber = parent.PhoneNumber;

                _dbContext.Update(currentParent);
            }

            _dbContext.SaveChanges();
        }

        public Parent GetParent(int id)
        {
            return _dbContext.Parents.First(p => p.ID == id);
        }

        public void SaveChild(Child child)
        {
            if (child.AccountId == 0)
                throw new Exception($"Неуспешно запазване на дете. Детето не е свързано със същесвуваща регистрация.");

            if (child.ID == 0)
            {
                Account account = _dbContext.Accounts.First(a => a.Id == child.AccountId);

                if (account.Children.Any(c => c.FirstName == child.FirstName && c.MiddleName == child.MiddleName && c.LastName == c.LastName))
                    throw new Exception($"Вече съществува дете на име {child.FirstName} {child.MiddleName} {child.LastName}.");

                _dbContext.Children.Add(child);
            }
            else
            {
                Child currentChild = _dbContext.Children.First(c => c.ID == child.ID);

                if (currentChild.AccountId != child.AccountId)
                    throw new Exception($"Неуспешно запазване на дете. Смяна на регистрацията на дете не е позволена.");

                currentChild.FirstName = child.FirstName;
                currentChild.MiddleName = child.MiddleName;
                currentChild.LastName = child.LastName;
                currentChild.BirthDate = child.BirthDate;

                _dbContext.Update(currentChild);
            }

            _dbContext.SaveChanges();
        }

        public Child GetChild(int id)
        {
            return _dbContext.Children.First(p => p.ID == id);
        }
    }
}