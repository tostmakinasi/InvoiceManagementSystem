namespace InvoiceManagement.Core.DTOs
{
    public class UserDto : BaseModelDto
    {
        public string FullName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CarLicensePlate { get; set; }


        public int ApartmentId { get; set; }
    }
}
