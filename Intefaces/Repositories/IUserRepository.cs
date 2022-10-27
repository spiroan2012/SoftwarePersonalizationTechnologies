using Models;
using Models.Params;
using PagedListForEFCore;

namespace Intefaces.Repositories
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<PagedList<AppUser>> GetUsersAsync(UserParams userParams);
        Task<AppUser?> GetUserByIdAsync(int id);
        Task<AppUser?> GetUserByEmailAsync(string? email);
        Task<AppUser?> GetUserByUsernameAsync(string? username);
        Task<string> HealthCheck();
        void UpdateUserLocationAsync(AppUser? user, double longt, double lat);
        Task<bool> Complete();
    }
}
