using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intefaces.Repositories
{
    public interface IGenreRepository
    {
        Task<IReadOnlyList<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
    }
}
