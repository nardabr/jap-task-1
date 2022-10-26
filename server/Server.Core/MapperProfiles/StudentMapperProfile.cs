using AutoMapper;
using Server.Core.Entities;
using Server.Core.Requests.Student;

namespace Server.Core.MapperProfiles
{
    public class StudentMapperProfile : Profile
    {
        public StudentMapperProfile()
        {
            CreateMap<Student, GetStudentDto>();
            CreateMap<StudentStatus, GetStudentStatusDto>();
            CreateMap<AddStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
            CreateMap<GetStudentLectureEventsDto, StudentLectureEvents>();
        }
    }
}
