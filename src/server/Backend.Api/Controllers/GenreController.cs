﻿namespace Backend.Api.Controllers
{
    using Backend.Business.Interfaces;
    using Backend.Api.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class GenreController : ApiController
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public GenreController(IMovieService movieService, IGenreService genreService) => 
            (_movieService, _genreService) = (movieService, genreService);

        [HttpGet]
        public IActionResult Get() => Ok(_genreService.GetAll());

        [HttpGet("{key}")]
        public async Task<IActionResult> GetAsync(int key) =>
            (await _genreService.GetAsync(key)).Match(genre => Ok(genre), NotFound);

        [HttpGet("{key}/movies")]
        public async Task<IActionResult> GetMoviesAsync(int key = 1, int pageSize = 20, int pageNumber = 1, string search = "") =>
            (await _genreService.GetAsync(key))
                .Map(_ => _movieService.FindMoviesByGenre(key, pageSize, pageNumber, search))
                .Match(movies => Ok(movies), NotFound);
    }
}