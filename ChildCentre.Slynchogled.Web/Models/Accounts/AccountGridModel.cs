using ChildCentre.Slynchogled.Web.Models.Accounts.Children;
using ChildCentre.Slynchogled.Web.Models.Accounts.Parents;

namespace ChildCentre.Slynchogled.Web.Models.Accounts
{
    public class AccountGridModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public List<ParentGridModel> Parents { get; set; }

        public List<ChildGridModel> Children { get; set; }
    }
}