using Microsoft.AspNetCore.Mvc;
using NEWSK8.Web.Data;

namespace NEWSK8.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class PostsController : Controller
    {
        private readonly IPostRepository postRepository;

        public PostsController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult GetPost()
        {
            return Ok(this.postRepository.GetAllWithUsers());
        }
    }
}
