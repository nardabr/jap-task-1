using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;
using Server.Core.Interfaces;
using Server.Core.Requests.Program;
using Server.Database;

namespace Server.Services
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
