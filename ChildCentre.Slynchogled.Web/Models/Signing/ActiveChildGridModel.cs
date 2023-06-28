namespace ChildCentre.Slynchogled.Web.Models.Signing
{
    public class ActiveChildGridModel
    {
        public int Id { get; set; }

        public int ChildId { get; set; }

        public int ChildNumber { get; set; }

        public string ChildName { get; set; }

        public DateTime? ChildBirthDate { get; set; }

        public string AccountName { get; set; }

        public string AccountPhone { get; set; }

        public DateTime SignedIn { get; set; }

        public bool WithParent { get; set; }
    }
}