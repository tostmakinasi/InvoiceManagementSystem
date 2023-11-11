using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InvoiceManagement.Core.ViewModels
{
    public class SignInViewModel
    {
        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [Display(Name = "Email :")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
