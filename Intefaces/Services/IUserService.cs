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
    }
}
