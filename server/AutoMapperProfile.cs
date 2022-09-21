using AutoMapper;
using jap_task.Dtos.Program;

namespace jap_task
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Program, GetProgramDto>();
        }
    }
}
