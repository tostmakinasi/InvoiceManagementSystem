using InvoiceManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.Repositories
{
    public interface IApartmentRepository:IGenericRepository<Apartment>
    {
        Task<List<Apartment>> GetApartments();
    }
}
