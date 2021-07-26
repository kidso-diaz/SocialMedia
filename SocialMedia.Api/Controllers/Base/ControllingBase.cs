using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Api.Controllers.Base
{
    public abstract class ControllingBase : ControllerBase
    {
        protected readonly IPostService _postService;
        protected readonly IMapper _mapper;

        public ControllingBase(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
    }
}
