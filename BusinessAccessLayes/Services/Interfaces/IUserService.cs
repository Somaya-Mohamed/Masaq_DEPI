using Shared.DataTransferObjects.Users;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(string id, UserUpdateDto request);
        Task<bool> DeleteAsync(string id);
    }
}
