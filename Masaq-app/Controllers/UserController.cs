using BusinessAccessLayes.ServiceManagers;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Users;

namespace Masaq_app.Controllers
{
    public class UserController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _serviceManager.UserService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _serviceManager.UserService.GetByIdAsync(id);
            if (user == null)
                return NotFound($"No user found with ID = {id}");
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateDto request)
        {
            var updated = await _serviceManager.UserService.UpdateAsync(id, request);
            if (!updated)
                return NotFound($"No user found with ID = {id}");
            return Ok("User updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var deleted = await _serviceManager.UserService.DeleteAsync(id);
            if (!deleted)
                return NotFound($"No user found with ID = {id}");
            return Ok("User deleted successfully");
        }
    }
}
