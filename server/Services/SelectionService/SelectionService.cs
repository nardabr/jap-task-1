using AutoMapper;
using jap_task.Data;
using jap_task.Dtos.Selection;
using jap_task.Models;
using jap_task.Services.SelectionService;
using Microsoft.EntityFrameworkCore;

namespace jap_task.Services.ProgramService
{
    public class SelectionService : ISelectionService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SelectionService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetSelectionDto>>> GetAllSelections()
        {
            var response = new ServiceResponse<List<GetSelectionDto>>();
            var dbSelections = await _context.Selections
                .Include(selection => selection.Status)
                .Include(selection => selection.Program)
                .ToListAsync();
            response.Data = dbSelections.Select(selection => _mapper.Map<GetSelectionDto>(selection)).ToList();
            return response;
        }
    }
}
