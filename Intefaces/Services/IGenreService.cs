using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intefaces.Services
{
    public interface IGenreService
    {
        Task<IList<GenreDto>> GetGenres();
    }
}
