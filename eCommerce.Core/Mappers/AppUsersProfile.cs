using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entity;

namespace eCommerce.Core.Mappers;

public class AppUsersProfile : Profile
{
    public AppUsersProfile()
    {
        CreateMap<AppUser, AuthenticationResponse>()
            .ForMember(dest => dest.UserId, opt =>
                opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt =>
                opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PersonName, opt =>
                opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender, opt =>
                opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.Token, opt =>
                opt.Ignore())
            .ForMember(dest => dest.Success, opt =>
                opt.Ignore());

    }
}