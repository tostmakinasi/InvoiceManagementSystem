using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.Models
{
    public class Apartment:BaseModel
    {
        public string Block { get; set; }
        public bool IsOccupied { get; set; }
        public string RoomType { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }

        public User OwnerOrTenant { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Dues> Dues { get; set; }
        public ICollection<Invoce> Invoces { get; set; }
    }
}
