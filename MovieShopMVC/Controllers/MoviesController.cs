using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // go to movie service -> call movie repository and get movie detalis from movies table
            var movieDetails = _movieService.GetMovieDetails(id);
            return View(movieDetails);
        }
    }
}
