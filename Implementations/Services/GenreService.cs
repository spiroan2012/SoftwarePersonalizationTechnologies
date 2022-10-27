using Dtos.Responses;
using Intefaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations.Services
{
    public class GenreService : IGenreService
    {
        public Task<IList<GenreDto>> GetGenres()
        {
            throw new NotImplementedException();
        }
    }
}
