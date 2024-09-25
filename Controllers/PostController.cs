using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPattern.Services.PostService;


namespace RepoPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>>GetAllPosts()
        {
            var result = await _postService.GetAllPosts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            if (post is null) return NotFound("Sorry not found.");  
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<List<Post>>> AddPost([FromBody]Post post)
        {
           var result = await _postService.AddPost(post);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(int id, Post request)
        {
            var result = await _postService.UpdatePost(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Post>>> DeletePost(int id)
        {
            var result = await  _postService.DeletePost(id);

            if (result is null) 
                return NotFound("Post is not found...");

            return Ok(result);
        }
    }
}
