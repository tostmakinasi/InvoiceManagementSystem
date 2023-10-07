namespace InvoiceManagement.Core.ViewModels
{
    public abstract class BaseModelViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
