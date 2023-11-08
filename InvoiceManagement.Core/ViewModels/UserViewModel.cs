using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.ViewModels;

namespace InvoiceManagement.Core.ViewModels
{
    public class UserViewModel 
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CarLicensePlate { get; set; }
        public string Picture { get; set; }

        public string Address { get; set; }
    }
}
