using InvoiceManagement.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManagement.Repository.Configurations
{
    public class UserConfiguration : BaseModelConfigurationration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirsName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IdentificationNumber).HasMaxLength(11);
            base.Configure(builder);
        }

    }
}
