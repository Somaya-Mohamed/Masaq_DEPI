using Shared.DataTransferObjects.Roles;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto> GetByIdAsync(string id);
        Task<RoleDto> CreateAsync(CreatAndUpdateRoleDto dto);
        Task<RoleDto> UpdateAsync(string id, CreatAndUpdateRoleDto dto);
        Task DeleteAsync(string id);
    }
}
