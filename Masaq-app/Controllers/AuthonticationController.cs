using BusinessAccessLayes.ServiceManagers;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Authentication;

namespace Masaq_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthonticationController(IServiceManager _servicemanager) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<UserResponce>> login(LoginRequest loginRequest)
        {
            var res = await _servicemanager.AuthenticationService.Login(loginRequest);
            return Ok(res);
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserResponce>> register(RegisterRequest RegisterRequest)
        {
            var res = await _servicemanager.AuthenticationService.Register(RegisterRequest);
            return Ok(res);
        }

        #region Forgot and Reset Password

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            await _servicemanager.AuthenticationService.SendPasswordResetEmail(request.Email);
            return Ok("Password reset email sent successfully.");
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPassword request)
        {
            var success = await _servicemanager.AuthenticationService.ResetPassword(request);
            if (!success) return BadRequest("Failed to reset password.");
            return Ok("Password reset successfully.");
        }

        #endregion
    }
}
