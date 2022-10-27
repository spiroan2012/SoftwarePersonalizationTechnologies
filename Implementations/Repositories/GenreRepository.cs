using Intefaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookingContext _context;

        public GenreRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public Task<Genre> GetGenreByIdAsync(int id)
        {
            return _context
                .Genres
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
