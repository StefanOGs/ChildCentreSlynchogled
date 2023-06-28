namespace ChildCentre.Slynchogled.Web.Models.Signing.SignIn
{
    public class SignInGridModel
    {
        public int ChildId { get; set; }

        public string ChildName { get; set; }

        public DateTime? ChildBirthDate { get; set; }

        public string AccountName { get; set; }

        public string AccountPhone { get; set; }
    }
}