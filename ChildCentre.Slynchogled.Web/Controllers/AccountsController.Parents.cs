using ChildCentre.Slynchogled.Data.Models;
using ChildCentre.Slynchogled.Web.Models.Accounts.Parents;
using Microsoft.AspNetCore.Mvc;

namespace ChildCentre.Slynchogled.Web.Controllers
{
    public partial class AccountsController : Controller
    {
        [HttpGet]
        [Route("Parents/New")]
        public IActionResult ParentNew(int accountId)
        {
            ViewData["Title"] = "Добавяне на родител";
            return PartialView(viewName: "Parents/ParentEdit", model: new ParentModel() { AccountId = accountId });
        }

        [HttpGet]
        [Route("Parents/Edit")]
        public IActionResult ParentEdit(int parentId)
        {
            ViewData["Title"] = "Редактиране на родител";
            Parent parent = _clientsService.GetParent(parentId);

            return PartialView(viewName: "Parents/ParentEdit", model: MapParentModel(parent));
        }

        [HttpPost]
        [Route("Parents/Save")]
        public IActionResult ParentSave(ParentModel parentModel)
        {
            if (ModelState.IsValid == false)
            {
                if (parentModel.Id > 0)
                    ViewData["Title"] = "Редактиране на родител";
                else
                    ViewData["Title"] = "Добавяне на родител";

                return PartialView(viewName: "Parents/ParentEdit", model: parentModel);
            }

            Parent parent = MapParent(parentModel);
            _clientsService.SaveParent(parent);

            return Ok();
        }

        #region Mappings

        private ParentGridModel MapParentGrid(Parent parent)
            => new ParentGridModel()
            {
                Id = parent.ID,
                Name = $"{parent.FirstName} {parent.MiddleName} {parent.LastName}",
                Phone = parent.PhoneNumber
            };

        private Parent MapParent(ParentModel parentModel)
            => new Parent()
            {
                ID = parentModel.Id,
                AccountId = parentModel.AccountId,
                FirstName = parentModel.FirstName,
                MiddleName = parentModel.MiddleName,
                LastName = parentModel.LastName,
                PhoneNumber = parentModel.PhoneNumber
            };

        private ParentModel MapParentModel(Parent parent)
            => new ParentModel()
            {
                Id = parent.ID,
                AccountId = parent.AccountId,
                FirstName = parent.FirstName,
                MiddleName = parent.MiddleName,
                LastName = parent.LastName,
                PhoneNumber = parent.PhoneNumber
            };

        #endregion
    }
}