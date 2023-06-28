using ChildCentre.Slynchogled.Data.Models;
using ChildCentre.Slynchogled.Services.Interfaces;
using ChildCentre.Slynchogled.Web.Models.Settings;
using ChildCentre.Slynchogled.Web.Models.Signing;
using Microsoft.AspNetCore.Mvc;

namespace ChildCentre.Slynchogled.Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public IActionResult Index()
        {
            Settings settings = _settingsService.GetSettings();
            SettingsModel settingsModel = MapSettingsModel(settings);

            return View(settingsModel);
        }

        #region Mappings

        private SettingsModel MapSettingsModel(Settings settings)
            => new SettingsModel()
            {
                Capacity = settings.Capacity,
                WorkHours = settings.WorkHours,
                PricePerHourChildOnly = settings.PricePerHourChildOnly,
                PricePerHourWithParent = settings.PricePerHourWithParent
            };

        #endregion
    }
}