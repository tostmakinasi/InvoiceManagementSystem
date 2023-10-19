using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.ViewModels
{
    public class ApartmentListViewModel
    {
        public int Id { get; set; }
        public string Block { get; set; }
        public string IsAvailable { get; set; } //Dolu or Boş
        public string HouseType { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public int InvoicesCount { get; set; }
        public string UserFullName { get; set; }
    }
}
