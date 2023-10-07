namespace InvoiceManagement.Core.ViewModels
{
    public class ApartmentViewModel : BaseModelViewModel
    {
        public string Block { get; set; }
        public bool IsAvailable { get; set; }
        //public string HouseType { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }

    }
}
