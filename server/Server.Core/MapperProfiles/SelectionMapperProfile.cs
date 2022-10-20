using AutoMapper;
using Server.Core.Entities;
using Server.Core.Requests.Selection;

namespace Server.Core.MapperProfiles
{
    public class SelectionMapperProfile : Profile
    {
        public SelectionMapperProfile()
        {
            CreateMap<Selection, GetSelectionDto>();
            CreateMap<SelectionStatus, GetSelectionStatusDto>();
            CreateMap<UpdateSelectionDto, Selection>();
        }
    }
}
