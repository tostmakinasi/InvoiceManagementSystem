using InvoiceManagement.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Repository.Configurations
{
    public class DuesConfiguration:BaseModelConfigurationration<Dues>
    {
        public override void Configure(EntityTypeBuilder<Dues> builder)
        {
            base.Configure(builder);
        }
    }
}
