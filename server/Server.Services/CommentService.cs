using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;
using Server.Core.Requests.Comment;
using Server.Core.Interfaces;
using Server.Database;

namespace Server.Services
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
        public async Task<ServiceResponse<GetCommentDto>> Create(CreateCommentDto createComment)
        {
            var student = await _context.Students
                            .FirstOrDefaultAsync(s => s.Id == createComment.StudentId);

            var comment = new Comment();
            _mapper.Map(createComment, comment);
            //comment.Text = createComment.Text;
            //comment.StudentId = createComment.StudentId;

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return new ServiceResponse<GetCommentDto>
            {
                Success = true,
                Message = "Comment is created successfuly."
                //serviceResponse.Data
            };
        }
    }
}
