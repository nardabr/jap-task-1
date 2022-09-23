using AutoMapper;
using jap_task.Dtos.Program;
using jap_task.Dtos.Selection;
using jap_task.Models;
using server.Dtos.Comment;
using server.Dtos.Selection;
using server.Dtos.Student;

namespace jap_task
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Program, GetProgramDto>();
            CreateMap<Comment, GetCommentDto>();

            CreateMap<Selection, GetSelectionDto>();
            CreateMap<UpdateSelectionDto, Selection>();

            CreateMap<Student, GetStudentDto>();
            CreateMap<AddStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
        }
    }
}
