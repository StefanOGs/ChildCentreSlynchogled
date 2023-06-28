using ChildCentre.Slynchogled.Data.Context;
using ChildCentre.Slynchogled.Data.Models;
using ChildCentre.Slynchogled.Services.Interfaces;

namespace ChildCentre.Slynchogled.Services.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ChildCentreContext _dbContext;

        public SettingsService(ChildCentreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Settings GetSettings()
        {
            return _dbContext.Settings.Single();
        }
    }
}