using AutoMapper;
using InvoiceManagement.Core.DTOs;
using InvoiceManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Services.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Apartment,ApartmentDto>().ReverseMap();
            CreateMap<Invoice,InvoiceDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
        }
    }
}
