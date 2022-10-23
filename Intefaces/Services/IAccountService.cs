using Dtos.Requests;
using Dtos.Responses;

namespace Intefaces.Services
{
    public interface IAccountService
    {
        Task<UserDto> RegisterNewUser(RegisterDto registerDto);
        Task<UserDto> UserLogin(LoginDto loginDto);
        //Task<UserDto> FacebookLogin(ExternalAuthDto externalAuthDto);
        Task<UserDto?> GoogleLogin(ExternalAuthDto externalAuthDto);
    }
}
