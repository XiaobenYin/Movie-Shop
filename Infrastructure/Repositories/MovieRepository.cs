using ApplicationCore.Entities;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
