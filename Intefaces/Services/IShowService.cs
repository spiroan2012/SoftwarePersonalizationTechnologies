using Dtos.Requests;
using Dtos.Responses;
using Models.Params;
using PagedListForEFCore;

namespace Intefaces.Services
{
    public interface IShowService
    {
        Task<Tuple<IList<ShowDto>, PagedListHeaders>> GetShows(ShowParams showParams);
        Task<ShowDto> GetShowById(int id);
        Task<ShowDto> Add(CreateShowDto createShowDto);
        Task<ShowHallDto> GetHallOfShow(int id);
        Task UpdateShow(ShowUpdateDto showUpdateDto, int id);
        Task DeleteShow(int id);
        Task ChangeHallOfShow(int showId, int newHallId);
        Task<IList<SeatsShowDto>> GetSeatsOfShow(int showId, DateTime showDate);
        Task<IList<ShowDto>> GetShowsForDate(DateTime dateGiven);
    }
}
