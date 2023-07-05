namespace InvoiceManagement.Core.DTOs
{
    public abstract class BaseModelDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
