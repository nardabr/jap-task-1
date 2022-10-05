using AutoMapper;
using jap_task.Models;
using server.Dtos.Student;

namespace server.MapperProfiles
{
    public class StudentMapperProfile : Profile
    {
        public StudentMapperProfile()
        {
            CreateMap<Student, GetStudentDto>();
            CreateMap<StudentStatus, GetStudentStatusDto>();
            CreateMap<AddStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
        }
    }
}
