using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.Users;

namespace BusinessAccessLayes.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly MasaqDbContext _dbContext;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper, MasaqDbContext dbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<bool> UpdateAsync(string id, UserUpdateDto request)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return false;

            var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.UserId == user.Id);
            if (student != null)
            {
                student.FullName = request.FullName;
                student.PhoneNumber = request.PhoneNumber;
                student.email = request.Email;
                _dbContext.Students.Update(student);
                await _dbContext.SaveChangesAsync();
            }
            var teaher = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.UserId == user.Id);
            if (teaher != null)
            {
                teaher.FullName = request.FullName;
                teaher.email = request.Email;
                _dbContext.Teachers.Update(teaher);
                await _dbContext.SaveChangesAsync();
            }

            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.FullName = request.FullName;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return false;

            var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.UserId == user.Id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.UserId == user.Id);
            if (teacher != null)
            {
                _dbContext.Teachers.Remove(teacher);
                await _dbContext.SaveChangesAsync();
            }

           await _userManager.RemoveFromRoleAsync(user , "STUDENT");
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }

}
