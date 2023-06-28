namespace ChildCentre.Slynchogled.Data.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual List<Parent> Parents { get; set; }

        public virtual List<Child> Children { get; set; }
    }
}