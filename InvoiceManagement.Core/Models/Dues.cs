using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.Models
{
    public class Dues:BaseModel
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }


        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
