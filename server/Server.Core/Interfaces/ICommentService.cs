using Server.Core.Entities;
using Server.Core.Requests.Comment;

namespace Server.Core.Interfaces
{
    public interface ICommentService
    {
        Task<ServiceResponse<GetCommentDto>> Create(CreateCommentDto createComment);
    }
}
