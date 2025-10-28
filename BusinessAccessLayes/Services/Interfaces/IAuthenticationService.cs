using Shared.DataTransferObjects.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserResponce>  Login(LoginRequest loginRequest);

        Task<UserResponce> Register (RegisterRequest registerRequest);
    }
}
