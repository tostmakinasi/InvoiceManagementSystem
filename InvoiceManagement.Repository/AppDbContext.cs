using InvoiceManagement.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InvoiceManagement.Repository
{
    public class AppDbContext : IdentityDbContext<User,Role,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Invoice> Invoces { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }

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
                if (entry.Entity is BaseModel entityReferance)
                {
                    switch (entry.State)
                    {
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entityReferance.IsDeleted = true;
                            entityReferance.UpdatedDate = DateTime.Now;
                            Entry(entityReferance).Property(x => x.CreatedDate).IsModified = false;
                            break;
                        case EntityState.Modified:
                            entityReferance.UpdatedDate = DateTime.Now;
                            Entry(entityReferance).Property(x => x.CreatedDate).IsModified = false;
                            break;
                        case EntityState.Added:
                            entityReferance.CreatedDate = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
