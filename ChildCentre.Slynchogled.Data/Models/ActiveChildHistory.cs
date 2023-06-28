namespace ChildCentre.Slynchogled.Data.Models
{
    public class ActiveChildHistory
    {
        public int ID { get; set; }

        public string AccountName { get; set; }

        public string AccountPhone { get; set; }

        public int ChildNumber { get; set; }

        public string ChildName { get; set; }

        public DateTime? ChildBirthDate { get; set; }

        public DateTime SignedIn { get; set; }

        public DateTime SignedOut { get; set; }

        public bool WithParent { get; set; }

        public decimal Price { get; set; }
    }
}