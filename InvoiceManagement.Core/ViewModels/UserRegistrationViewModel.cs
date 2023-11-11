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
    public class UserRegistrationViewModel
    {

        [Required(ErrorMessage = "İsim alanı zorunludur")]
        [Display(Name = "İsim :")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [Display(Name = "Soyad :")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı için bir Daire seçmelisiniz.")]
        [Display(Name = "Daire :")]
        public int ApartmentId { get; set; }

        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunludur.")]
        [Display(Name = "Telefon :")]
        public string Phone { get; set; }
    }
}
