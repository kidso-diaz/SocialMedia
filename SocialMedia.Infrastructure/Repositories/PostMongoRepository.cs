using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostMongoRepository : IPostRepository
    {
        public Task<IEnumerable<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }

        Task<Post> IPostRepository.GetPost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
