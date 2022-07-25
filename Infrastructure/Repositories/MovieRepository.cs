using ApplicationCore.Entities;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieShopDbContext _movieShopDbContext;

        public MovieRepository(MovieShopDbContext movieShopDbContext)
        {
            _movieShopDbContext = movieShopDbContext;
        }

        public Movie GetById(int id)
        {
            // select * from movie where id = passed-in id join genre, cast, moviegenre, moviecast
            var movieDetails = _movieShopDbContext.Movies
                .Include(m=>m.GenresOfMovie)
                .ThenInclude(m=>m.Genre)
                .Include(m=>m.CastsOfMovie)
                .ThenInclude(m=>m.Cast)
                .Include(m=>m.Trailers)
                .FirstOrDefault(m=>m.Id == id);
            return movieDetails;
        }

        public MovieDetailsModel GetMovieDetails(int movieId)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetTop30HighestRevenueMovies()
        {
            // call the db with EF Core and get the data
            // use MovieShopDbContext and Movies DbSet
            // select top 30 from Movies order by Revenue
            // we need to write corresponding LINQ query

            var movies = _movieShopDbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }

        public List<Movie> GetTop30RatedMovies()
        {
            throw new NotImplementedException();
        }
    }
}
