using System.ComponentModel.DataAnnotations.Schema;

namespace ChildCentre.Slynchogled.Data.Models
{
    public class Child
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; }
    }
}