using AutoMapper;
using jap_task.Models;
using server.Dtos.Comment;

namespace server.MapperProfiles
{
    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {
            CreateMap<Comment, GetCommentDto>();
            CreateMap<CreateCommentDto, Comment>();
        }
    }
}
