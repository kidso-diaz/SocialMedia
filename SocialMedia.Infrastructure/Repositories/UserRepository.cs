using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(SocialMediaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var users = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return users;
        }
    }
}
