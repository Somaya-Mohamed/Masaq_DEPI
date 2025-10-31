using BusinessAccessLayes.Services.Interfaces;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.IdentityModels;
using DataAccessLayer.Models.Students;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.DataTransferObjects.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessAccessLayes.Services.Classes
{
    public class Authentication(UserManager<ApplicationUser> _usermanager, MasaqDbContext _dbContext, IConfiguration _config, IEmailService _emailService) : IAuthenticationService
    {
        public async Task<UserResponce> Login(LoginRequest loginRequest)
        {
            //after this tow lines of code we should through exception that user with this id is not found 
            var user = await _dbContext.Students.FirstOrDefaultAsync(s => s.PhoneNumber == loginRequest.phoneNumber);
            var appuser = await _usermanager.FindByIdAsync(user.UserId);

            var res = await _usermanager.CheckPasswordAsync(appuser, loginRequest.password);
            if (!res)
            {
                throw new UnauthorizedAccessException();
            }

            return new UserResponce()
            {
                FullName = user.FullName,
                phonenumber = user.PhoneNumber,
                Token = await generateJwtToken(user)

            };
        }

        public async Task<UserResponce> Register(RegisterRequest registerRequest)
        {
            var user = new ApplicationUser()
            {
                Role = "Student",
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                PhoneNumber = registerRequest.PhoneNumber,
                FullName = registerRequest.FullName,


            };
            var res = await _usermanager.CreateAsync(user, registerRequest.Password);
            if (!res.Succeeded)
            {
                throw new Exception(string.Join(", ", res.Errors.Select(e => e.Description)));
            }
            var stu = new Student()
            {
                FullName = registerRequest.FullName,
                PhoneNumber = registerRequest.PhoneNumber,
                ParentPhoneNumber = registerRequest.parentPhonenumber,
                levelFK = registerRequest.LevelNumber,
                Government = registerRequest.Government,
                UserId = user.Id,
                email = registerRequest.Email
            };

            await _dbContext.Students.AddAsync(stu);
            await _dbContext.SaveChangesAsync();

            return new UserResponce()
            {
                FullName = stu.FullName,
                phonenumber = stu.PhoneNumber,
                Token = await generateJwtToken(stu)
            };
        }
        private async Task<string> generateJwtToken(Student student)
        {

            var user = await _usermanager.FindByIdAsync(student.UserId);
            var roles = await _usermanager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , student.UserId),
                new Claim(ClaimTypes.Name , student.FullName),

            };
            foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

            var secretkey = _config["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
    issuer: _config["Jwt:Issuer"],
    audience: _config["Jwt:Audience"],
    claims: claims,
    expires: DateTime.UtcNow.AddHours(int.Parse(_config["Jwt:ExpiresInDays"])),
    signingCredentials: creds
);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #region Forgot and Reset Password
        public async Task<bool> ResetPassword(ResetPassword request)
        {
            var user = await _usermanager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new Exception("User not found.");

            var result = await _usermanager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            return result.Succeeded;
        }

        public async Task<string> GeneratePasswordResetToken(string email)
        {
            var user = await _usermanager.FindByEmailAsync(email);
            if (user == null)
                throw new Exception("User not found.");

            var token = await _usermanager.GeneratePasswordResetTokenAsync(user);
            return token;
        }

        public async Task SendPasswordResetEmail(string email)
        {
            var user = await _usermanager.FindByEmailAsync(email);
            if (user == null) throw new Exception("User not found.");

            var token = await _usermanager.GeneratePasswordResetTokenAsync(user);
            //string resetLink = $"https://yourfrontend.com/reset-password?email={email}&token={WebUtility.UrlEncode(token)}";
            string resetLink = $"https://localhost:7182/api/Authontication/reset-password?email={email}&token={token}";

            string subject = "Password Reset Request";
            string body = $"Click the link to reset your password: <a href='{resetLink}'>Reset Password</a>";

            await _emailService.SendEmailAsync(email, subject, body);
        }
        #endregion
    }
}
