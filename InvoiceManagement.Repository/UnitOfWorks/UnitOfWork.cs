using InvoiceManagement.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
