using InvoiceManagement.Core.Enums;

namespace InvoiceManagement.Core.ViewModels
{
    public class InvoiceViewModel : BaseModelViewModel
    { 
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public BillingPeriod BillingPeriod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }

        public int ApartmentId { get; set; }
    }
}
