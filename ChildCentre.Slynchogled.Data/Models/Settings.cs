namespace ChildCentre.Slynchogled.Data.Models
{
    public class Settings
    {
        public int ID { get; set; }

        public string WorkHours { get; set; }

        public int Capacity { get; set; }

        public decimal PricePerHourChildOnly { get; set; }

        public decimal PricePerHourWithParent { get; set; }
    }
}