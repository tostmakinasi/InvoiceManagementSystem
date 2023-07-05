using InvoiceManagement.Core.Enums;

namespace InvoiceManagement.Core.Models
{
    public class Invoice : BaseModel
    {
        public decimal Amount { get; set; }
        public BillingPeriod BillingPeriod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }

        public int InvoiceTypeId { get; set; }
        public Invoice InvoceType { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
