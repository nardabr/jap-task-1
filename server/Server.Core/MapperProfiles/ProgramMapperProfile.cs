using AutoMapper;
using Server.Core.Requests.Program;

namespace Server.Core.MapperProfiles
{
    public class ProgramMapperProfile : Profile
    {
        public ProgramMapperProfile()
        {
            CreateMap<Entities.Program, GetProgramDto>();
        }

    }
}
