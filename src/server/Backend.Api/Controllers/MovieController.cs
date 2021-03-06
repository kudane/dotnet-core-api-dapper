﻿namespace Backend.Api.Controllers
{
    using Backend.Api.Controllers.Base;
    using Backend.Business.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MovieController : ApiController
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service) => (_service) = (service);

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetAll());

        [HttpGet("{key}")]
        public async Task<IActionResult> GetAsync(int key) =>
            (await _service.GetAsync(key)).Match(movie => Ok(movie), NotFound);
    }
}
