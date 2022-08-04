using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("top-revenue")] //attribute routing
                               // MVC(traditional/conventinoal based routing) http://localhost/movies/gettoprevenuemovies
                               // API routing http://localhost/api/movies/top-revenue
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTopRevenueMovies();
            if (movies == null || !movies.Any())
            {
                // 404
                return NotFound(new
                {
                    errorMessage = "No Movies Found"
                });
            }
            // 202
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return NotFound(new { errorMessage = $"No Movie Found for {id}" });
            }
            return Ok(movie);
        }
    }
}
