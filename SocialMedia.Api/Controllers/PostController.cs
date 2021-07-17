using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();
            var postsDto = posts.Select(x => new PostDto()
            {
                PostId = x.PostId,
                PostDate = x.PostDate,
                Description = x.Description,
                Image = x.Image,
                UserId = x.UserId
            });
            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            var postDto = new PostDto()
            {
                PostId = post.PostId,
                PostDate = post.PostDate,
                Description = post.Description,
                Image = post.Image,
                UserId = post.UserId
            };
            return Ok(postDto);
        }

        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = new Post()
            {
                PostId = postDto.PostId,
                PostDate = postDto.PostDate,
                Description = postDto.Description,
                Image = postDto.Image,
                UserId = postDto.UserId
            };
            await _postRepository.InsertPost(post);
            return Ok(post);
        }
    }
}
