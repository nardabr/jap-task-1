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

        public async Task<ServiceResponse<List<GetProgramDto>>> GetAll()
        {
            return new ServiceResponse<List<GetProgramDto>>
            {
                Data = await _context.Programs
                   .Select(program => _mapper.Map<GetProgramDto>(program))
                   .ToListAsync()  
            };
        }
    }
}
