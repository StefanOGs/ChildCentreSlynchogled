using ChildCentre.Slynchogled.Data.Models;
using ChildCentre.Slynchogled.Services.Interfaces;
using ChildCentre.Slynchogled.Services.Services;
using ChildCentre.Slynchogled.Web.Models.Accounts;
using ChildCentre.Slynchogled.Web.Models.Accounts.Children;
using ChildCentre.Slynchogled.Web.Models.Accounts.Parents;
using ChildCentre.Slynchogled.Web.Models.Signing.SignIn;
using Microsoft.AspNetCore.Mvc;

namespace ChildCentre.Slynchogled.Web.Controllers
{
    public partial class AccountsController : Controller
    {
        private readonly IClientsService _clientsService;

        public AccountsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpGet]
        [Route("Accounts")]
        public IActionResult AccountsGrid()
        {
            List<Account> accounts = _clientsService.GetAccounts();
            List<AccountGridModel> gridModels = accounts.Select(acc => MapAccountGrid(acc)).ToList();

            return View(gridModels);
        }

        [HttpGet]
        [Route("Accounts/New")]
        public IActionResult AccountNew()
        {
            AccountNewModel accountModel = new AccountNewModel();
            return View(accountModel);
        }

        [HttpPost]
        [Route("Accounts/New")]
        public IActionResult AccountNew(AccountNewModel accountModel)
        {
            if (ModelState.IsValid == false)
                return View(accountModel);

            try
            {
                Account account = MapAccount(accountModel);
                _clientsService.RegisterAccount(account);
            }
            catch (Exception ex)
            {
                ViewData["NewAccountError"] = ex.Message;
                return View(viewName: "AccountNew", model: accountModel);
            }

            return RedirectToAction(nameof(AccountsGrid));
        }

        [HttpGet]
        [Route("Accounts/Details/{id}")]
        public IActionResult AccountDetails(int id)
        {
            Account account = _clientsService.GetAccount(id);
            AccountDetailsModel accountModel = MapAccountDetailsModel(account);

            return View(accountModel);
        }

        #region Mappings

        private AccountGridModel MapAccountGrid(Account account)
            => new AccountGridModel()
            {
                Id = account.Id,
                Name = account.Name,
                Phone = account.PhoneNumber,
                Parents = account.Parents?.Select(p => MapParentGrid(p))?.ToList() ?? new List<ParentGridModel>(),
                Children = account.Children?.Select(c => MapChildGrid(c))?.ToList() ?? new List<ChildGridModel>()
            };

        private Account MapAccount(AccountNewModel accountNewModel)
            => new Account()
            {
                Name = $"{accountNewModel.Parent.FirstName} {accountNewModel.Parent.MiddleName} {accountNewModel.Parent.LastName}",
                PhoneNumber = accountNewModel.Parent.PhoneNumber,
                CreatedOn = DateTime.Now,
                Parents = new List<Parent>() { MapParent(accountNewModel.Parent) },
                Children = new List<Child>() { MapChild(accountNewModel.Child) }
            };

        private AccountDetailsModel MapAccountDetailsModel(Account account)
            => new AccountDetailsModel()
            {
                Id = account.Id,
                Name = account.Name,
                PhoneNumber = account.PhoneNumber,
                CreatedOn = account.CreatedOn,
                Parents = account.Parents?.Select(p => MapParentGrid(p))?.ToList() ?? new List<ParentGridModel>(),
                Children = account.Children?.Select(c => MapChildGrid(c))?.ToList() ?? new List<ChildGridModel>()
            };

        #endregion
    }
}