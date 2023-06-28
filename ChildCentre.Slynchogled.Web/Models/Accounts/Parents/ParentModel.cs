using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChildCentre.Slynchogled.Web.Models.Accounts.Parents
{
    public class ParentModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        [Required(ErrorMessage = "Родителят трябва да е свързан със съществуваща регистрация.")]
        public int AccountId { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Полето е задължително.")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        public string? MiddleName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Полето е задължително.")]
        public string LastName { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Полето е задължително.")]
        [RegularExpression("\\d*", ErrorMessage = "Полето за телефонен номер трябва да съдържа само числа.")]
        public string PhoneNumber { get; set; }
    }
}