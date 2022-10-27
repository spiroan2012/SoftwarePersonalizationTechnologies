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
        Task<IReadOnlyList<Genre>> GetGenresForUser(int userId);
        void UpdateUserLocationAsync(AppUser? user, double longt, double lat);
        void RemoveGenresForUser(AppUser? user);
        void AddGenreForUser(Genre? genre, AppUser? user);
        Task<bool> Complete();
    }
}
