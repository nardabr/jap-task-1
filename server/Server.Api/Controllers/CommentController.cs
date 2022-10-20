using Microsoft.AspNetCore.Mvc;
using Server.Core.Interfaces;
using Server.Core.Requests.Comment;

namespace Server.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentDto createComment)
        {
            return Ok(await _commentService.Create(createComment));
        }
    }
}
