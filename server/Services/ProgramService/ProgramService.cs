using AutoMapper;
using jap_task.Data;
using jap_task.Dtos.Program;
using jap_task.Models;
using Microsoft.EntityFrameworkCore;

namespace jap_task.Services.ProgramService
{
    public class ProgramService : IProgramService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProgramService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //public async Task<ServiceResponse<List<GetProgramDto>>> GetAllPrograms()
        //{
        //    var response = new ServiceResponse<List<GetProgramDto>>();
        //    var dbPrograms = await _context.Programs.ToListAsync();
        //    response.Data = dbPrograms.Select(c => _mapper.Map<GetProgramDto>(c)).ToList();
        //    return response;
        //}

        public async Task<ServiceResponse<List<GetProgramDto>>> GetAllPrograms()
        {
            var response = new ServiceResponse<List<GetProgramDto>>();
            var dbPrograms = await _context.Programs.ToListAsync();
            response.Data = dbPrograms.Select(c => new GetProgramDto
            {
                ProgramName = c.ProgramName,
                ProgramDescription = c.ProgramDescription,
            }).ToList();
            return response;
        }

        //public async Task<ServiceResponse<List<GetProgramDto>>> GetAllPrograms()
        //{
        //    var response = new ServiceResponse<List<GetProgramDto>> 
        //    {
        //        Data = await _context.Programs
        //        .Select(p => _mapper.Map<GetProgramDto>(p)).ToListAsync()
        //    };
        //    return response;
        //}
    }
}
