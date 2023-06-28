using ChildCentre.Slynchogled.Data.Models;
using ChildCentre.Slynchogled.Web.Models.Accounts.Children;
using Microsoft.AspNetCore.Mvc;

namespace ChildCentre.Slynchogled.Web.Controllers
{
    public partial class AccountsController : Controller
    {
        [HttpGet]
        [Route("Children/New")]
        public IActionResult ChildNew(int accountId)
        {
            ViewData["Title"] = "Добавяне на дете";
            return PartialView(viewName: "Children/ChildEdit", model: new ChildModel() { AccountId = accountId });
        }

        [HttpGet]
        [Route("Children/Edit")]
        public IActionResult ChildEdit(int childId)
        {
            ViewData["Title"] = "Редактиране на дете";
            Child child = _clientsService.GetChild(childId);

            return PartialView(viewName: "Children/ChildEdit", model: MapChildModel(child));
        }

        [HttpPost]
        [Route("Children/Save")]
        public IActionResult ChildSave(ChildModel childModel)
        {
            if (ModelState.IsValid == false)
            {
                if (childModel.Id > 0)
                    ViewData["Title"] = "Редактиране на дете";
                else
                    ViewData["Title"] = "Добавяне на дете";

                return PartialView(viewName: "Children/ChildEdit", model: childModel);
            }

            Child child = MapChild(childModel);
            _clientsService.SaveChild(child);

            return Ok();
        }

        #region Mappings
        private ChildGridModel MapChildGrid(Child child)
            => new ChildGridModel()
            {
                Id = child.ID,
                Name = child.MiddleName == null
                    ? $"{child.FirstName} {child.LastName}"
                    : $"{child.FirstName} {child.MiddleName} {child.LastName}",
                BirthDate = child.BirthDate
            };

        private Child MapChild(ChildModel childModel)
            => new Child()
            {
                ID = childModel.Id,
                AccountId = childModel.AccountId,
                FirstName = childModel.FirstName,
                MiddleName = childModel.MiddleName,
                LastName = childModel.LastName,
                BirthDate = childModel.BirthDate
            };

        private ChildModel MapChildModel(Child child)
            => new ChildModel()
            {
                Id = child.ID,
                AccountId = child.AccountId,
                FirstName = child.FirstName,
                MiddleName = child.MiddleName,
                LastName = child.LastName,
                BirthDate = child.BirthDate
            };

        #endregion
    }
}