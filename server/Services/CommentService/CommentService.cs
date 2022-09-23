using AutoMapper;
using jap_task.Data;
using jap_task.Models;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Comment;
using server.Dtos.Student;

namespace server.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CommentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<GetCommentDto>> CreateComment(CreateCommentDto createComment)
        {
            var student = await _context.Students
                            .FirstOrDefaultAsync(s => s.Id == createComment.StudentId);

            var comment = new Comment();
            comment.Text = createComment.Text;
            comment.StudentId = (int)createComment.StudentId;

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<GetCommentDto>();
            serviceResponse.Success = true;
            serviceResponse.Message = "Comment is created successfuly.";
            //serviceResponse.Data
            return serviceResponse;
        }
    }
}
