using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post()
            {
                PostId = x,
                Description = $"Description {x}",
                PostDate = DateTime.Now,
                Image = $"https://pisapis.com/{x}",
                UserId = x * 2
            });

            await Task.Delay(10);

            return posts;
        }
    }
}
