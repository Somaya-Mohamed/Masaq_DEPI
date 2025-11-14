using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects.Roles;

namespace BusinessAccessLayes.Mapping_Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IdentityRole, RoleDto>().ReverseMap();
            CreateMap<CreatAndUpdateRoleDto, IdentityRole>();
        }
    }
}
