using AutoMapper;
using InvoiceManagement.Core.ViewModels;
using InvoiceManagement.Core.Models;

namespace InvoiceManagement.Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            
            CreateMap<InvoiceType, InvoiceTypeViewModel>().ReverseMap();
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();

            CreateMap<User, UserViewModel>()
                .ForMember(x => x.Address, opt => opt.MapFrom(src => (src.ApartmentId != null && src.Apartment != null) ? $"{src.Apartment.Block} - Kat: {src.Apartment.FloorNumber}, Daire: {src.Apartment.ApartmentNumber}" : "Adres bilgisi mevcut değil"))
                .ForMember(x=> x.FullName, opt=> opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForAllMembers(x=> x.NullSubstitute("-"));

            CreateMap<UserRegistrationViewModel, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(x=> x.FirstName,opt=> opt.MapFrom(src => src.FirstName))
                .ForMember(x=> x.PhoneNumber,opt=> opt.MapFrom(src=> src.Phone));
                

            CreateMap<HouseType,HouseTypeViewModel>().ReverseMap();

            CreateMap<Apartment, ApartmentListViewModel>()
                .ForMember(x=> x.IsAvailable, opt=> opt.MapFrom(src => src.IsAvailable ? "Boş" : "Dolu"))
                .ForMember(x=> x.HouseType, opt=> opt.MapFrom(src => src.HouseType.Name))
                .ForMember(dest => dest.InvoicesCount, opt => opt.MapFrom(src => src.Invoices.Count))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User != null ? $"{src.User.FirstName} {src.User.LastName}" : ""));
            CreateMap<Apartment, ApartmentSelectionListViewModel>()
                .ForMember(x => x.AparmnentAddress, opt => opt.MapFrom(src => $"{src.Block}, Daire: {src.ApartmentNumber}"));
            CreateMap<Apartment, ApartmentCreateViewModel>().ReverseMap();
        }
    }
}
