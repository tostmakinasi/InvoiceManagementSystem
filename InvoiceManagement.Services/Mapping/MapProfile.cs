using AutoMapper;
using InvoiceManagement.Core.ViewModels;
using InvoiceManagement.Core.Models;

namespace InvoiceManagement.Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Apartment, ApartmentViewModel>();
            CreateMap<InvoiceType, InvoiceTypeViewModel>().ReverseMap();
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
