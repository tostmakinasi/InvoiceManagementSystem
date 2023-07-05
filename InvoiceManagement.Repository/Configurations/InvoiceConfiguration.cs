using InvoiceManagement.Core.Enums;
using InvoiceManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManagement.Repository.Configurations
{
    public class InvoiceConfiguration : BaseModelConfigurationration<Invoice>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.IsPaid).HasDefaultValue(false);
            base.Configure(builder);

        }
    }
}
