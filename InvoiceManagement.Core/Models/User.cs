using Microsoft.AspNetCore.Identity;

namespace InvoiceManagement.Core.Models
{
    public class User : BaseModel
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string CarLicensePlate { get; set; }


        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
