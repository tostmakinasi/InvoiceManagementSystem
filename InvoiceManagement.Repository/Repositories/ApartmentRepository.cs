using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Repository.Repositories
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Apartment>> GetApartments()
        {
            var apartments = await _context.Apartments.AsNoTracking().Include(x => x.User).Include(x => x.HouseType).Include(x => x.Invoices).ToListAsync();

            return apartments;
        }
    }
}
