using ApplicationCore.Models;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService

    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieCardModel> GetTopRevenueMovies()
        {
            // communicate with repositories
            var movies = _movieRepository.GetTop30HighestRevenueMovies();
            var movieCards = new List<MovieCardModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel { Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl });
            }

            return movieCards;
        }
    }
}
