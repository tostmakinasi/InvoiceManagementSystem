using InvoiceManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Repository.Seeds
{
    internal class HouseTypeSeed : IEntityTypeConfiguration<HouseType>
    {
        public void Configure(EntityTypeBuilder<HouseType> builder)
        {
            builder.HasData(new HouseType { Id = 1, Name = "Studio" },
            new HouseType { Id = 2, Name = "One Bedroom" },
            new HouseType { Id = 3, Name = "Two Bedroom" },
            new HouseType { Id = 4, Name = "Three Bedroom" },
            new HouseType { Id = 5, Name = "Four Bedroom" },
            new HouseType { Id = 6, Name = "Five Bedroom" },
            new HouseType { Id = 7, Name = "Six Bedroom" },
            new HouseType { Id = 8, Name = "Seven Bedroom" },
            new HouseType { Id = 9, Name = "Eight Bedroom" },
            new HouseType { Id = 10, Name = "Nine Bedroom" },
            new HouseType { Id = 11, Name = "Ten Bedroom" });
        }
    }
}
