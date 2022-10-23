using Models;
using Models.Params;
using PagedListForEFCore;

namespace Intefaces.Repositories
{
    public interface IHallRepository
    {
        Task<Hall> GetHallByIdAsync(int id);
        Task<PagedList<Hall>> GetAllHallsAsync(HallParams hallParams);
        Task<IReadOnlyList<Show>> GetShowsOfHallAsync(int id, HallParams hallParams);
        Task<IReadOnlyList<Hall>> GetHallsWithoutPaginationAsync();
        void Add(Hall hall);
        void AddShow(Hall hall, Show show);
        Task<bool> Complete();
        void Update(Hall hall);
    }
}
