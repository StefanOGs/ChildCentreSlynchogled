using ChildCentre.Slynchogled.Web.Models.Accounts.Children;
using ChildCentre.Slynchogled.Web.Models.Accounts.Parents;
using System.ComponentModel.DataAnnotations;

namespace ChildCentre.Slynchogled.Web.Models.Accounts
{
    public class AccountDetailsModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Създадена на")]
        public DateTime CreatedOn { get; set; }

        public List<ParentGridModel> Parents { get; set; }

        public List<ChildGridModel> Children { get; set; }
    }
}