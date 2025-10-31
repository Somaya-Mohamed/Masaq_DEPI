using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects.Roles;

namespace BusinessAccessLayes.Services.Classes
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = _roleManager.Roles.ToList();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> CreateAsync(CreatAndUpdateRoleDto dto)
        {
            var role = new IdentityRole { Name = dto.Name };
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> UpdateAsync(string id, CreatAndUpdateRoleDto dto)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) throw new Exception("Role not found");

            role.Name = dto.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return _mapper.Map<RoleDto>(role);
        }

        public async Task DeleteAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) throw new Exception("Role not found");

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}
