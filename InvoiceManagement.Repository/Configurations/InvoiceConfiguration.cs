using InvoiceManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Repository.Configurations
{
    public class InvoiceConfiguration:BaseModelConfigurationration<Invoce>
    {
        public override void Configure(EntityTypeBuilder<Invoce> builder)
        {
            builder.Property(x => x.InvoceType).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.IsPaid).HasDefaultValue(false);
            base.Configure(builder);
        }
    }
}
