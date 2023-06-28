using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChildCentre.Slynchogled.Web.Models.Accounts.Children
{
    public class ChildModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        [Required(ErrorMessage = "Детето трябва да е свързано със съществуваща регистрация.")]
        public int AccountId { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Полето е задължително.")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        public string? MiddleName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Полето е задължително.")]
        public string LastName { get; set; }

        [Display(Name = "Рождена дата")]
        public DateTime? BirthDate { get; set; }
    }
}