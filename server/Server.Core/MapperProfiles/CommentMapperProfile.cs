using AutoMapper;
using Server.Core.Entities;
using Server.Core.Requests.Comment;

namespace Server.Core.MapperProfiles
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
