using AutoMapper;
using jap_task.Dtos.Selection;
using jap_task.Models;
using server.Dtos.Selection;

namespace server.MapperProfiles
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
