﻿using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryContracts
{
    public interface IMovieRepository
    {
        // CRUD operations regarding Movie table
        // use movie entity

        // method to get top 30 highest grossing movies
        Task<List<Movie>> GetTop30HighestRevenueMovies();

        Task<List<Movie>> GetTop30RatedMovies();

        Task<Movie> GetById(int id);
        MovieDetailsModel GetMovieDetails(int movieId);
        Task<PagedResultSet<Movie>> GetMovieByGenrePagination(int genreId, int pageSize = 30, int page = 1);
    }
}
