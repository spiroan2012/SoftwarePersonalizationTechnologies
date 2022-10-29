using AutoMapper;
using Dtos.Responses;
using Intefaces.Repositories;
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
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<IList<GenreDto>> GetGenres()
        {
            var genres = await _genreRepository.GetAllGenresAsync();
            return _mapper.Map<IList<GenreDto>>(genres);
        }

        public async Task<GenreDto> GetGenreById(int id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);

            return _mapper.Map<GenreDto>(genre);
        }
    }
}
