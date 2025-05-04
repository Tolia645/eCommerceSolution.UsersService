using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entity;

namespace eCommerce.Core.Mappers;

public class RegisterRequestToAppUsers : Profile
{
    public RegisterRequestToAppUsers()
    {
        CreateMap<RegisterRequest, AppUser>()
            .ForMember(dest => dest.PersonName, opt =>
                opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Email, opt =>
                opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt =>
                opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Gender, opt =>
                opt.MapFrom(src => src.Gender));
    }
}