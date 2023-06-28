using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChildCentre.Slynchogled.Web.Models.Signing.SignIn
{
    public class SignInModel
    {
        [HiddenInput]
        [Required(ErrorMessage = "Полето е задължително.")]
        public int ChildId { get; set; }

        [Display(Name = "Дете")]
        [Required(ErrorMessage = "Полето е задължително.")]
        public string ChildName { get; set; }

        [Display(Name = "Номер")]
        [Required(ErrorMessage = "Полето е задължително.")]
        [Range(1, 100, ErrorMessage = "Номерът на детето трябва да бъде между 1 и 100.")]
        public int ChildNumber { get; set; }

        [Display(Name = "С придружител")]
        [Required(ErrorMessage = "Полето е задължително.")]
        public bool WithParent { get; set; }
    }
}