using InvoiceManagement.Core.ViewModels;

namespace InvoiceManagement.Core.ViewModels
{
    public class UserViewModel : BaseModelViewModel
    {
        public string FullName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CarLicensePlate { get; set; }


        public int ApartmentId { get; set; }
    }
}
