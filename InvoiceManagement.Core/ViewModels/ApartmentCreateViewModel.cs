using InvoiceManagement.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace InvoiceManagement.Core.ViewModels
{
    public class ApartmentCreateViewModel : BaseModelViewModel
    {
        [Required(ErrorMessage = "Apartman Adı zorunludur.")]
        [Display(Name = "Apartman Adı :")]
        public string Block { get; set; }

        [Required(ErrorMessage = "Müsaitlik Durumu zorunludur.")]
        [Display(Name = "Müsaitlik Durumu  :")]
        public bool IsAvailable { get; set; } = true;

       
        [Display(Name = "Daire Türü  :")]
        [Range(1, int.MaxValue, ErrorMessage = "Bir Daire Türü seçmelisiniz.")]
        public int HouseTypeId { get; set; }

        [Required(ErrorMessage = "Kat zorunludur.")]
        [Display(Name = "Kat :")]
        public int FloorNumber { get; set; }

        [Required(ErrorMessage = "Daire Numarası zorunludur.")]
        [Display(Name = "Daire Numarası  :")]
        public int ApartmentNumber { get; set; }

    }
}
