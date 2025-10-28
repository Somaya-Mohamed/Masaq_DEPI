using BusinessAccessLayes.ServiceManagers;
using Microsoft.AspNetCore.Http;
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
    }
}
