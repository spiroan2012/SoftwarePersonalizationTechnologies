using GeoCoordinatePortable;
using Implementations;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Params;
using PagedListForEFCore;

namespace Intefaces.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly BookingContext _context;

        public ShowRepository(BookingContext context)
        {
            _context = context;
        }

        public void Add(Show show)
        {
            _context.Shows?.Add(show);
        }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PagedList<Show>> GetAllShowsAsync(ShowParams showParams)
        {
            var query = _context.Shows?.Include(s => s.Hall).Include(s => s.Genre).AsQueryable();

            if (!string.IsNullOrWhiteSpace(showParams.SearchTitle))
            {
                query = query?.Where(s => s.Title!.Contains(showParams.SearchTitle));
            }
            query = query?.Where(s => s.DateEnd >= DateTime.Now);

            query = showParams.OrderBy switch
            {
                "title" => query?.OrderByDescending(s => s.Title),
                _ => query?.OrderByDescending(s => s.DateStart)
            };
            return await PagedList<Show>.CreateAsync(query!, showParams.PageNumber, showParams.PageSize);
        }

        public async Task<Hall> GetHallOfShowAsync(int id)
        {
            var show = await _context.Shows!.Include(h => h.Hall)
                .SingleOrDefaultAsync(p => p.Id == id);
            return show?.Hall!;
        }

        public async Task<Show?> GetShowByIdAsync(int id)
        {
            return await _context.Shows!
                .Include(s => s.Hall)
                .Include(s => s.Genre)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Show? Show)
        {
            _context.Entry(Show!).State = EntityState.Modified;
        }

        public void Delete(Show show)
        {
            _context.Shows?.Remove(show);
        }

        public async Task<IReadOnlyList<Show>> GetShowsForSpecificDateAsync(DateTime dateGiven)
        {
            return await _context.Shows!
                .Include(s => s.Hall)
                .Include(s => s.Genre)
                .Where(p => dateGiven >= p.DateStart && dateGiven <= p.DateEnd)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Show>> GetShowsRecomendations(int[] favoriteGenres, int[] bookedShowsIds)
        {
            var query = _context.Shows ?
                .Include(s => s.Hall)
                .Include(s => s.Genre)
                .Where(s => s.DateEnd >= DateTime.Now && favoriteGenres.Contains(s.Genre.Id) && !bookedShowsIds.Contains(s.Id));

            return await query.ToListAsync();
        }

        public async Task<Genre> GetGenreOfShow(int showId)
        {
            return await _context
                .Shows
                .Include(s => s.Genre)
                .Where(s => s.Id == showId)
                .Select(s => s.Genre)
                .FirstOrDefaultAsync();
        }
    }
}
