using System.ComponentModel.DataAnnotations;

namespace InvoiceManagement.Core.ViewModels
{
    public class AccountCompletionViewModel
    {

        public string FullName { get; set; }

        [Display(Name = "Daire :")]
        public string Apartment { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Şifreler eşleşmedi.")]
        [Required(ErrorMessage = "Şifre Tekrar zorunludur.")]
        [Display(Name = "Şifre Tekrar :")]
        public string PasswordConfirm { get; set; }
    }
}
