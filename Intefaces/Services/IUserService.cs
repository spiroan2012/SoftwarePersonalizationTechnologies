using Dtos.Requests;
using Dtos.Responses;
using Models.Params;
using PagedListForEFCore;

namespace Intefaces.Services
{
    public interface IUserService
    {
        public Task<Tuple<IList<UserDto>, PagedListHeaders>> GetUsers(UserParams userParams);
        public Task<IList<UserDto>> GetById(string id);
        public Task<IList<UserDto>> GetByUsername(string username);
        Task<IList<GenreDto>> GetGenresForUser(int userId);
        public Task UpdateUserLocation(string userId, LocationDto locationDto);
        Task UpdateGenresForLoggedUser(int[] genresId, int userId);
    }
}
