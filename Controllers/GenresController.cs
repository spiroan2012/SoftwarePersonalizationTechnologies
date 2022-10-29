using Dtos.Responses;
using Implementations.Services;
using Intefaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genresService;

        public GenresController(IGenreService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<GenreDto>>> GetAllGenres()
        {
            return Ok(await _genresService.GetGenres());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IList<GenreDto>>> GetGenresById(int id)
        {
            return Ok(await _genresService.GetGenreById(id));
        }
    }
}
