using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Api.Controllers.Base
{
    public abstract class ControllingBase : ControllerBase
    {
        protected readonly IPostRepository _postRepository;
        protected readonly IMapper _mapper;

        public ControllingBase(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
    }
}
