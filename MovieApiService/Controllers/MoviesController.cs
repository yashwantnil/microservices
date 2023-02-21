using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApiService.Models;
using MovieApiService.Models.DTOs;

namespace MovieApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Black Panther",
                    Genre = "Action"
                },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Snake in the Eagle Shadow",
                    Genre = "Thriller"
                }
            };
            return Ok(movies);
        }
        [HttpPost]
        [Authorize(Policy ="Admin")]
        public IActionResult CreateMovies(CreateMovieDTO model)
        {
            //Validate the incoming data and store in the Db 
            Movie movie = new Movie()
            {
                Id= Guid.NewGuid(),
                Name = model.Name, 
                Genre = model.Genre
            };
            return Ok(movie); 
        }
    }
}
