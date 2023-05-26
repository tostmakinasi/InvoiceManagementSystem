using InvoiceManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.Models
{
    public class Invoce:BaseModel
    {
        public InvoceType InvoceType { get; set; }
        public decimal Amount { get; set; }
        public BillingPeriod BillingPeriod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
