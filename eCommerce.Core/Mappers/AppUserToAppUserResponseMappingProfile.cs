using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entity;

namespace eCommerce.Core.Mappers;

public class AppUserToAppUserResponseMappingProfile : Profile
{
    public AppUserToAppUserResponseMappingProfile()
    {
        CreateMap<AppUser, AppUserResponse>()
            .ForMember(dest => dest.UserId, opt =>
                opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt =>
                opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PersonName, opt =>
                opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender, opt =>
                opt.MapFrom(src => src.Gender));
    }
}