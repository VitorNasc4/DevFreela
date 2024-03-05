using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User> GetUserByEmailAndPasswordAsyn(string email, string passwordHash)
        {
            return _dbContext.Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}