using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManagement.Repository.Configurations
{
    public class UserConfiguration : BaseModelConfigurationration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IdentificationNumber).HasMaxLength(11);
            base.Configure(builder);
        }
        
    }
}
