using Models;
using Models.Params;
using PagedListForEFCore;

namespace Intefaces.Repositories
{
    public interface IShowRepository
    {
        void Add(Show show);
        void Delete(Show show);
        Task<PagedList<Show>> GetAllShowsAsync(ShowParams showParams);
        Task<Show?> GetShowByIdAsync(int id);
        Task<Hall> GetHallOfShowAsync(int id);
        Task<bool> Complete();
        void Update(Show? show);
        Task<IReadOnlyList<Show>> GetShowsForSpecificDateAsync(DateTime dateGiven);
        Task<IReadOnlyList<Show>> GetShowsRecomendations(int[] favoriteGenres, int[] bookedShowsIds);
        Task<Genre> GetGenreOfShow(int showId);
    }
}
