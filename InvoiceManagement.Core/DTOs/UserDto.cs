using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.DTOs
{
    public class UserDto:BaseModelDto
    {
        public string FullName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string VehiclePlateNumber { get; set; }


        public int ApartmentId { get; set; }
    }
}
