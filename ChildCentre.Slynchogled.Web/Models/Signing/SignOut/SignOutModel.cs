using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChildCentre.Slynchogled.Web.Models.Signing.SignOut
{
    public class SignOutModel
    {
        [HiddenInput]
        public int ActiveChildId { get; set; }

        [Display(Name = "Номер на детето")]
        public int ChildNumber { get; set; }

        [Display(Name = "Дете")]
        public string ChildName { get; set; }

        [Display(Name = "Рождена дата")]
        public DateTime? ChildBirthDate { get; set; }

        [Display(Name = "Регистрация")]
        public string AccountName { get; set; }

        [Display(Name = "Телефон")]
        public string AccountPhone { get; set; }

        [Display(Name = "Вписано в")]
        public DateTime? SignedIn { get; set; }

        [HiddenInput]
        public DateTime? SignedOut { get; set; }

        [Display(Name = "Прекарано време")]
        public TimeSpan? TimeSpent { get; set; }

        [Display(Name = "Цена (ЛВ)")]
        public decimal? Price { get; set; }
    }
}