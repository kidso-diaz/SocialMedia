using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Post
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            #endregion
        }
    }
}
