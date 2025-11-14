using AutoMapper;
using DataAccessLayer.Models.IdentityModels;
using Shared.DataTransferObjects.Users;

namespace BusinessAccessLayes.Mapping_Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName
                ))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src =>
                    src.PhoneNumber
                ))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        }
    }
}
