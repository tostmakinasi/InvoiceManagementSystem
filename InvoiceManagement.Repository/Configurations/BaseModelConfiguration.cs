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
    public abstract class BaseModelConfigurationration<TBase> : IEntityTypeConfiguration<TBase>
    where TBase : BaseModel
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(x=> x.IsDeleted).HasDefaultValue(false);

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }

    }

}
