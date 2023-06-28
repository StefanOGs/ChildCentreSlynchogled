using ChildCentre.Slynchogled.Data.Models;
using ChildCentre.Slynchogled.Services.Interfaces;
using ChildCentre.Slynchogled.Web.Models.Signing;
using ChildCentre.Slynchogled.Web.Models.Signing.SignIn;
using ChildCentre.Slynchogled.Web.Models.Signing.SignOut;
using Microsoft.AspNetCore.Mvc;

namespace ChildCentre.Slynchogled.Web.Controllers
{
    [Route("Signing")]
    public class SigningController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly ICentreService _centreService;

        public SigningController(ISettingsService settingsService, ICentreService centreService)
        {
            _settingsService = settingsService;
            _centreService = centreService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ActiveChildren")]
        public IActionResult ActiveChildren()
        {
            List<ActiveChild> activeChildren = _centreService.GetActiveClients();
            List<ActiveChildGridModel> gridModels = activeChildren.Select(ac => MapActiveChildGrid(ac)).ToList();

            ViewData["Capacity"] = _settingsService.GetSettings().Capacity;

            return View(gridModels);
        }

        [HttpGet]
        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View(viewName: "SignIn/SignIn", model: new SignInModel());
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid == false)
                return View(viewName: "SignIn/SignIn", model: signInModel);

            try
            {
                _centreService.SignInClient(signInModel.ChildId, signInModel.ChildNumber, signInModel.WithParent, DateTime.Now);
            }
            catch (Exception ex)
            {
                ViewData["ChildNumberError"] = ex.Message;
                return View(viewName: "SignIn/SignIn", model: signInModel);
            }

            return RedirectToAction(nameof(ActiveChildren));
        }

        [HttpGet]
        [Route("SignIn/Grid")]
        public IActionResult SignInGrid()
        {
            List<Child> inactiveChildren = _centreService.GetInactiveClients();
            List<SignInGridModel> gridModels = inactiveChildren.Select(c => MapSignInGridModel(c)).ToList();

            return PartialView(viewName: "SignIn/SignInGrid", model: gridModels);
        }

        [HttpGet]
        [Route("SignOut")]
        public IActionResult SignOut(int? childNumber)
        {
            return View(viewName: "SignOut/SignOut", new SignOutModel() { ChildNumber = childNumber ?? default });
        }

        [HttpPost]
        [Route("SignOut")]
        public IActionResult SignOut(SignOutModel signOutModel)
        {
            if (ModelState.IsValid == false)
                return View(viewName: "SignOut/SignOut", model: signOutModel);

            _centreService.SignOutClient(signOutModel.ChildNumber, signOutModel.SignedOut.Value);

            return RedirectToAction(nameof(ActiveChildren));
        }

        // TODO HH: Business logic must not be here, but in its own layer...
        [HttpGet]
        [Route("SignOut/Find")]
        public IActionResult SignOutSearch(int childNumber)
        {
            ActiveChild activeChild = _centreService.GetActiveClient(childNumber);
            SignOutModel signOutModel = null;

            if (activeChild != null)
            {
                DateTime signedOut = DateTime.Now;

                signOutModel = MapSignOutModel(activeChild);

                decimal pricePerHour = activeChild.WithParent
                    ? _settingsService.GetSettings().PricePerHourWithParent
                    : _settingsService.GetSettings().PricePerHourChildOnly;

                TimeSpan timeSpent = signedOut - signOutModel.SignedIn.Value;

                decimal price = Math.Round(pricePerHour * (decimal)timeSpent.TotalHours, 1);

                signOutModel.SignedOut = signedOut;
                signOutModel.TimeSpent = timeSpent;
                signOutModel.Price = price;
            }

            if (activeChild == null)
            {
                return Json(new
                {
                    error = $"Не е намерено активно дете с номер {childNumber}."
                });
            }
            else
            {
                return PartialView(viewName: "SignOut/SignOutDetails", model: signOutModel);
            }
        }

        [HttpGet]
        [Route("SignOut/Grid")]
        public IActionResult SignOutGrid()
        {
            List<ActiveChild> activeChildren = _centreService.GetActiveClients();
            List<SignOutGridModel> gridModels = activeChildren.Select(ac => MapSignOutGridModel(ac)).ToList();

            return PartialView(viewName: "SignOut/SignOutGrid", model: gridModels);
        }

        #region Mappings

        private ActiveChildGridModel MapActiveChildGrid(ActiveChild activeChild)
            => new ActiveChildGridModel()
            {
                Id = activeChild.ID,
                ChildId = activeChild.ChildId,
                ChildNumber = activeChild.ChildNumber,
                ChildName = activeChild.Child.MiddleName == null
                    ? $"{activeChild.Child.FirstName} {activeChild.Child.LastName}"
                    : $"{activeChild.Child.FirstName} {activeChild.Child.MiddleName} {activeChild.Child.LastName}",
                ChildBirthDate = activeChild.Child.BirthDate,
                AccountName = activeChild.Child.Account.Name,
                AccountPhone = activeChild.Child.Account.PhoneNumber,
                WithParent = activeChild.WithParent,
                SignedIn = activeChild.SignedIn
            };

        private SignInGridModel MapSignInGridModel(Child child)
            => new SignInGridModel()
            {
                ChildId = child.ID,
                ChildName = child.MiddleName == null
                    ? $"{child.FirstName} {child.LastName}"
                    : $"{child.FirstName} {child.MiddleName} {child.LastName}",
                ChildBirthDate = child.BirthDate,
                AccountName = child.Account.Name,
                AccountPhone = child.Account.PhoneNumber
            };

        private SignOutGridModel MapSignOutGridModel(ActiveChild activeChild)
            => new SignOutGridModel()
            {
                ActiveChildId = activeChild.ID,
                ChildNumber = activeChild.ChildNumber,
                ChildName = activeChild.Child.MiddleName == null
                    ? $"{activeChild.Child.FirstName} {activeChild.Child.LastName}"
                    : $"{activeChild.Child.FirstName} {activeChild.Child.MiddleName} {activeChild.Child.LastName}",
                ChildBirthDate = activeChild.Child.BirthDate,
                AccountName = activeChild.Child.Account.Name,
                AccountPhone = activeChild.Child.Account.PhoneNumber,
                SignedIn = activeChild.SignedIn
            };

        private SignOutModel MapSignOutModel(ActiveChild activeChild)
            => new SignOutModel()
            {
                ActiveChildId = activeChild.ID,
                ChildNumber = activeChild.ChildNumber,
                ChildName = activeChild.Child.MiddleName == null
                    ? $"{activeChild.Child.FirstName} {activeChild.Child.LastName}"
                    : $"{activeChild.Child.FirstName} {activeChild.Child.MiddleName} {activeChild.Child.LastName}",
                ChildBirthDate = activeChild.Child.BirthDate,
                SignedIn = activeChild.SignedIn,
                AccountName = activeChild.Child.Account.Name,
                AccountPhone = activeChild.Child.Account.PhoneNumber
            };

        #endregion
    }
}