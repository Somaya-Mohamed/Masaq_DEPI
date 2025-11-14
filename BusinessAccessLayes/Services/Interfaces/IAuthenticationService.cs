using Shared.DataTransferObjects.Authentication;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserResponce> Login(LoginRequest loginRequest);

        Task<UserResponce> Register(RegisterRequest registerRequest);
        #region Forgot and Reset Password

        Task<string> GeneratePasswordResetToken(string email);
        Task<bool> ResetPassword(ResetPassword request);
        public Task SendPasswordResetEmail(string email);
        #endregion
    }
}
