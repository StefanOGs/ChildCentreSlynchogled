using System.ComponentModel.DataAnnotations.Schema;

namespace ChildCentre.Slynchogled.Data.Models
{
    public class Parent
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; }
    }
}