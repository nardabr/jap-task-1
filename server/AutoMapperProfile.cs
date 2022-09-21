﻿using AutoMapper;
using jap_task.Dtos.Program;
using jap_task.Dtos.Selection;
using jap_task.Models;

namespace jap_task
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Program, GetProgramDto>();
            CreateMap<Selection, GetSelectionDto>();
        }
    }
}
