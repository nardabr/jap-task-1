using AutoMapper;
using Server.Core.Entities;
using Server.Core.Requests.LectureEvent;

namespace Server.Core.MapperProfiles
{
    public class LectureEventMapperProfile : Profile
    {
        public LectureEventMapperProfile()
        {
            CreateMap<LectureEvent, GetLectureEventDto>();
            CreateMap<AddLectureEventDto, LectureEvent>();
            CreateMap<UpdateLectureEventDto, LectureEvent>();
        }
    }
}
