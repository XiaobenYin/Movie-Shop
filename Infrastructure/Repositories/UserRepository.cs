using ApplicationCore.Entities;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieShopDbContext _movieShopDbContext;

        public UserRepository(MovieShopDbContext movieShopDbContext)
        {
            _movieShopDbContext = movieShopDbContext;
        }

        public async Task<User> AddUser(User user)
        {
            _movieShopDbContext.Users.Add(user);
            await _movieShopDbContext.SaveChangesAsync();
            return user;
        }

        public Task<User> GetUserByEmail(string email)
        {
            var user = _movieShopDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
