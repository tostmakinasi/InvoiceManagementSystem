using AutoMapper;
using InvoiceManagement.Core.DTOs;
using InvoiceManagement.Core.Models;

namespace InvoiceManagement.Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<InvoiceType, InvoiceTypeDto>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
