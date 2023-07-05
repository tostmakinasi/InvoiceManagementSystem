using InvoiceManagement.Core.Enums;
using InvoiceManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManagement.Repository.Configurations
{
    public class ApartmentConfiguration : BaseModelConfigurationration<Apartment>
    {
        public override void Configure(EntityTypeBuilder<Apartment> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Block).IsRequired();
            builder.Property(x => x.IsOccupied).HasDefaultValue(false).IsRequired();
            builder.Property(x => x.HouseType).HasDefaultValue(HouseType.Studio).IsRequired();
            builder.Property(x => x.FloorNumber).IsRequired();
            builder.Property(x => x.ApartmentNumber).IsRequired();


        }
    }
}
