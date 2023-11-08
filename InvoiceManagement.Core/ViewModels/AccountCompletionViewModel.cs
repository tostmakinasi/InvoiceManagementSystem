using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InvoiceManagement.Core.ViewModels
{
    public class AccountCompletionViewModel
    {
        [Required(ErrorMessage ="İsim alanı zorunludur")]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [MaxLength(11,ErrorMessage ="TC Kimlik Numarası en çok 11 karakter olabilir.")]
        [MinLength(11, ErrorMessage = "TC Kimlik Numarası en az 11 karakter olabilir.")]
        [Required(ErrorMessage = "TC Kimlik No alanı zorunludur")]
        [Display(Name = "TC Kimlik No")]
        public string IdentificationNumber { get; set; }

        
        [Display(Name = "Plaka Numarası :")]
        public string CarLicensePlate { get; set; }

        [Display(Name ="Daire :")]
         public string Apartment{ get; set; }

        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunludur.")]
        [Display(Name = "Telefon :")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Şifreler eşleşmedi.")]
        [Required(ErrorMessage = "Şifre Tekrar zorunludur.")]
        [Display(Name = "Şifre Tekrar :")]
        public string PasswordConfirm { get; set; }
    }
}
