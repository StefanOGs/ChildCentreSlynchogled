using ChildCentre.Slynchogled.Data.Context;
using ChildCentre.Slynchogled.Data.Models;
using ChildCentre.Slynchogled.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChildCentre.Slynchogled.Services.Services
{
    public class CentreService : ICentreService
    {
        private readonly ChildCentreContext _dbContext;
        private readonly ISettingsService _settingsService;

        public CentreService(ChildCentreContext dbContext, ISettingsService settingsService)
        {
            _dbContext = dbContext;
            _settingsService = settingsService;
        }

        public void SignInClient(int childId, int childNumber, bool withParent, DateTime signedIn)
        {
            if (_dbContext.ActiveChildren.Any(ac => ac.ChildNumber == childNumber))
                throw new Exception($"Вече има вписано дете с номер {childNumber}.");

            //int centreCapacity = _settingsService.GetSettings().Capacity;

            //if (_dbContext.ActiveChildren.Count() + 1 > centreCapacity)
            //    throw new Exception($"Не могат да бъдат вписани повече деца, тъй като центърът е със запълнен капацитет от {centreCapacity} деца.");

            ActiveChild activeChild = new ActiveChild()
            {
                ChildId = childId,
                ChildNumber = childNumber,
                WithParent = withParent,
                SignedIn = signedIn
            };

            _dbContext.ActiveChildren.Add(activeChild);
            _dbContext.SaveChanges();
        }

        public void SignOutClient(int childNumber, DateTime signedOut)
        {
            Settings centreSettings = _settingsService.GetSettings();

            ActiveChild activeChild = _dbContext.ActiveChildren.Include(ac => ac.Child).ThenInclude(c => c.Account).First(ac => ac.ChildNumber == childNumber);

            decimal pricePerHour = activeChild.WithParent
                ? centreSettings.PricePerHourWithParent
                : centreSettings.PricePerHourChildOnly;

            ActiveChildHistory activeChildHistory = new ActiveChildHistory()
            {
                ChildNumber = activeChild.ChildNumber,
                ChildName = activeChild.Child.MiddleName == null
                    ? $"{activeChild.Child.FirstName} {activeChild.Child.LastName}"
                    : $"{activeChild.Child.FirstName} {activeChild.Child.MiddleName} {activeChild.Child.LastName}",
                ChildBirthDate = activeChild.Child.BirthDate,
                AccountName = activeChild.Child.Account.Name,
                AccountPhone = activeChild.Child.Account.PhoneNumber,
                SignedIn = activeChild.SignedIn,
                SignedOut = signedOut,
                WithParent = activeChild.WithParent,
                Price = Math.Round(pricePerHour * (decimal)(signedOut - activeChild.SignedIn).TotalHours, 1)
            };

            _dbContext.ActiveChildren.Remove(activeChild);
            _dbContext.ActiveChildrenHistory.Add(activeChildHistory);

            _dbContext.SaveChanges();
        }

        public ActiveChild GetActiveClient(int number)
        {
            return _dbContext.ActiveChildren.Include(ac => ac.Child).ThenInclude(c => c.Account).FirstOrDefault(ac => ac.ChildNumber == number);
        }

        public List<ActiveChild> GetActiveClients()
        {
            return _dbContext.ActiveChildren.Include(ac => ac.Child).ThenInclude(c => c.Account).ToList();
        }

        public List<Child> GetInactiveClients()
        {
            List<int> activeChildrenIds = _dbContext.ActiveChildren.Select(ac => ac.ChildId).ToList();
            return _dbContext.Children.Include(nameof(Child.Account)).Where(c => activeChildrenIds.Contains(c.ID) == false).ToList();
        }
    }
}