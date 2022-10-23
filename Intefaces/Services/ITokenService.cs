using Dtos.Requests;
using Google.Apis.Auth;
using Models;

namespace Intefaces.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth);
    }
}
