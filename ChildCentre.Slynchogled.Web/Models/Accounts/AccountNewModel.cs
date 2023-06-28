using ChildCentre.Slynchogled.Web.Models.Accounts.Children;
using ChildCentre.Slynchogled.Web.Models.Accounts.Parents;

namespace ChildCentre.Slynchogled.Web.Models.Accounts
{
    public class AccountNewModel
    {
        public ParentModel Parent { get; set; }

        public ChildModel Child { get; set; }
    }
}