using jap_task.Models;
using server.Dtos.Comment;

namespace server.Services.CommentService
{
    public interface ICommentService
    {
        Task<ServiceResponse<GetCommentDto>> CreateComment(CreateCommentDto createComment);
    }
}
