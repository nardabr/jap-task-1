using jap_task.Models;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Comment;
using server.Dtos.Student;
using server.Services.CommentService;

namespace server.Controllers
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
