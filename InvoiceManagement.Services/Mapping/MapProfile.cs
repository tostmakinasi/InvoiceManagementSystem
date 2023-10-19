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

            CreateMap<Apartment, ApartmentListViewModel>()
                .ForMember(x=> x.IsAvailable, opt=> opt.MapFrom(src => src.IsAvailable ? "Boş" : "Dolu"))
                .ForMember(x=> x.HouseType, opt=> opt.MapFrom(src => src.HouseType.Name))
                .ForMember(dest => dest.InvoicesCount, opt => opt.MapFrom(src => src.Invoices.Count))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User != null ? $"{src.User.FirsName} {src.User.LastName}" : ""));
        }
    }
}
