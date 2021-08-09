using SocialMedia.Core.Entities;
using SocialMedia.Core.Entities.Base;
using SocialMedia.Core.Entities.Customs;
using SocialMedia.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        IPagedList<Post> GetPosts(PostQueryFilter filter);
        Task<Post> GetPost(int id);
        Task InsertPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}