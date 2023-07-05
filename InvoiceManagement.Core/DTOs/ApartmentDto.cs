namespace InvoiceManagement.Core.DTOs
{
    public class ApartmentDto : BaseModelDto
    {
        public string Block { get; set; }
        public bool IsOccupied { get; set; }
        public string HouseType { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }

        public int OwnerOrTenantId { get; set; }
    }
}
