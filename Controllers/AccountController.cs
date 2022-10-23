using Dtos.Requests;
using Dtos.Responses;
using Intefaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var response = await _accountService.RegisterNewUser(registerDto);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var response = await _accountService.UserLogin(loginDto);
            return Ok(response);
        }

        [HttpPost("google-login")]
        public async Task<ActionResult<UserDto>> FacebookLogin(ExternalAuthDto externalAuthDto)
        {
            var response = await _accountService.GoogleLogin(externalAuthDto);
            return Ok(response);
        }
    }
}