using InvoiceManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InvoiceManagement.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[nameof(BaseModel.IsDeleted)] = true;
                        entry.CurrentValues[nameof(BaseModel.UpdatedDate)] = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues[nameof(BaseModel.UpdatedDate)] = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.CurrentValues[nameof(BaseModel.CreatedDate)] = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
