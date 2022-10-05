using AutoMapper;
using jap_task.Dtos.Program;

namespace server.MapperProfiles
{
    public class ProgramMapperProfile : Profile
    {
        public ProgramMapperProfile()
        {
            CreateMap<jap_task.Models.Program, GetProgramDto>();
        }

    }
}
