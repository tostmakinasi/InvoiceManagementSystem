using InvoiceManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Repository.Seeds
{
    internal class InvoiceTypeSeed : IEntityTypeConfiguration<InvoiceType>
    {
        public void Configure(EntityTypeBuilder<InvoiceType> builder)
        {
            builder.HasData(
                new InvoiceType { Id = 1, Name = "Aidat" }, 
                new InvoiceType { Id = 2, Name = "Doğal Gaz" }, 
                new InvoiceType { Id = 3, Name = "Elektirik" }, 
                new InvoiceType { Id = 4, Name = "Su" }
                );
        }
    }
}
