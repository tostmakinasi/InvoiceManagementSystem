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
    internal class ApartmentSeed : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasData(
                new Apartment { Id = 1, ApartmentNumber = 1, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 0, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 2, ApartmentNumber = 2, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 0, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 3, ApartmentNumber = 3, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 1, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 4, ApartmentNumber = 4, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 1, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 5, ApartmentNumber = 5, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 2, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 6, ApartmentNumber = 6, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 2, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 7, ApartmentNumber = 7, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 3, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 8, ApartmentNumber = 7, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 3, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 9, ApartmentNumber = 7, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 4, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 10, ApartmentNumber = 7, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 4, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 11, ApartmentNumber = 7, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 5, HouseTypeId = 3, IsAvailable = true },
                new Apartment { Id = 12, ApartmentNumber = 7, Block = "Duru Apt.", CreatedDate = DateTime.Now, FloorNumber = 5, HouseTypeId = 3, IsAvailable = true });
        }
    }
  
}
