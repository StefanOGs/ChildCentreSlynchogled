using System.ComponentModel.DataAnnotations;

namespace ChildCentre.Slynchogled.Web.Models.Settings
{
    public class SettingsModel
    {
        [Display(Name = "Работно време")]
        public string WorkHours { get; set; }

        [Display(Name = "Капацитет")]
        public int Capacity { get; set; }

        [Display(Name = "Цена на час (ЛВ)")]
        public decimal PricePerHourChildOnly { get; set; }

        [Display(Name = "Цена на час с придружител (ЛВ)")]
        public decimal PricePerHourWithParent { get; set; }
    }
}