using AutoMapper;
using jap_task.Data;
using jap_task.Dtos.Selection;
using jap_task.Models;
using jap_task.Services.SelectionService;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Selection;
using server.Dtos.Student;
using System.Diagnostics;
using System.Reflection;

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

            //var dbStudents = await _context.Students.Where(student => student.SelectionId == selection.Id);
            response.Data = dbSelections.Select(selection => _mapper.Map<GetSelectionDto>(selection)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetSelectionDto>> GetSelectionById(int id)
        {
            var response = new ServiceResponse<GetSelectionDto>();
            var dbSelection = await _context.Selections
                .Include(selection => selection.Status)
                .Include(selection => selection.Program)
                .FirstOrDefaultAsync(selection => selection.Id == id);

            var dbStudents = await _context.Students.Where(student => student.SelectionId == id).ToListAsync();
            response.Data =  _mapper.Map<GetSelectionDto>(dbSelection);
            response.Data.Students = dbStudents;
            //response.Data.Students = dbStudents.ForEach(student => { student.Id = id});
            return response;
        }

        public async Task<ServiceResponse<GetSelectionDto>> UpdateSelection(int id, UpdateSelectionDto updateSelection)
        {
            ServiceResponse<GetSelectionDto> response = new ServiceResponse<GetSelectionDto>();

            try
            {
                var selection = await _context.Selections
                        .Include(s => s.Status)
                        .Include(s => s.Program)
                        .FirstOrDefaultAsync(s => s.Id == id)
                        ?? throw new Exception("Selection with that id does not exist.");            

                var program = await _context.Programs
                        .FirstOrDefaultAsync(s => s.Id == updateSelection.ProgramId)
                        ?? throw new Exception("Program with that id does not exist.");
                 
                    var status = await _context.SelectionStatuses
                        .FirstOrDefaultAsync(s => s.Id == updateSelection.SelectionStatusId)
                        ?? throw new Exception("Selection Status with that id does not exist.");

                _mapper.Map(updateSelection, selection);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetSelectionDto>(selection);
                response.Success = true;
                response.Message = "Selection is edited successfuly.";

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
