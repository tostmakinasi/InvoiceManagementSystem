using InvoiceManagement.Core.Enums;

namespace InvoiceManagement.Core.DTOs
{
    public class InvoiceDto : BaseModelDto
    { 
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public BillingPeriod BillingPeriod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }

        public int ApartmentId { get; set; }
    }
}
