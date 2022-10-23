using Dtos.Responses;
using Models.Params;
using PagedListForEFCore;

namespace Intefaces.Services
{
    public interface IAdminService
    {
        Task<Tuple<IList<UserRoleDto>, PagedListHeaders>> GetUsersAndRoles(UserParams userParams);
        Task<bool> ChangeUserStatus(string username);
        Task<IList<string>> EditRoles(string username, string roles);
    }
}
