using InvoiceManagement.Core.Enums;

namespace InvoiceManagement.Core.Models
{
    public class Apartment : BaseModel
    {
        public string Block { get; set; }
        public bool IsAvailable { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }

        //Foreign Key
        public int HouseTypeId { get; set; }
        public virtual HouseType HouseType { get; set; }

        //Navigation
        public virtual User User { get; set; }
        public virtual ICollection<Invoice> Invoces { get; set; }
    }
}
