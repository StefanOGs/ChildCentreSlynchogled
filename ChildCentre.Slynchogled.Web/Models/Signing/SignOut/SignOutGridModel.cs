namespace ChildCentre.Slynchogled.Web.Models.Signing.SignOut
{
    public class SignOutGridModel
    {
        public int ActiveChildId { get; set; }

        public int ChildNumber { get; set; }

        public DateTime SignedIn { get; set; }

        public string ChildName { get; set; }

        public DateTime? ChildBirthDate { get; set; }

        public string AccountName { get; set; }

        public string AccountPhone { get; set; }
    }
}