using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : RepositoryBase, IPostRepository
    {
        public PostRepository(SocialMediaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            return post;
        }

        public async Task InsertPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            var currentPost = await GetPost(post.Id);

            #region Asignment
            currentPost.PostDate = post.PostDate;
            currentPost.Description = post.Description;
            currentPost.Comments = post.Comments;
            currentPost.Image = post.Image;
            currentPost.UserId = post.UserId;
            #endregion

            var rowsAffected = await _context.SaveChangesAsync();
            return (rowsAffected > 0);
        }

        public async Task<bool> DeletePost(int id)
        {
            var currentPost = await GetPost(id);
            _context.Posts.Remove(currentPost);

            int rowsAffected = await _context.SaveChangesAsync();
            return (rowsAffected > 0);
        }
    }
}
