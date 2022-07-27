using ApplicationCore.Models;
using ApplicationCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreService _genreService;
        public GenreService(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<List<GenreModel>> GetALlGenres()
        {
            var genres = await _genreService.GetALlGenres();
            var genresModels = genres.Select(g => new GenreModel
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
            return genresModels;
        }
    }
}
