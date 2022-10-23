using Dtos.Requests;
using Dtos.Responses;
using Models.Params;
using PagedListForEFCore;

namespace Intefaces.Services
{
    public interface IHallsService
    {
        Task<Tuple<IList<HallDto>, PagedListHeaders>> GetHalls(HallParams hallParams);
        Task<HallDto> GetHallById(int id);
        Task<IList<ShowDto>> GetShowsOfHall(int id, HallParams hallParams);
        Task<IList<HallDto>> GetWithoutPagination();
        Task AddHall(HallDto hallDto);
        Task UpdateHall(HallUpdateDto hallUpdateDto, int id);
    }
}
