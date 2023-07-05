using InvoiceManagement.Core.Enums;

namespace InvoiceManagement.Core.Models
{
    public class Apartment : BaseModel
    {
        public string Block { get; set; }
        public bool IsOccupied { get; set; }
        public HouseType HouseType { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Invoice> Invoces { get; set; }
    }
}
