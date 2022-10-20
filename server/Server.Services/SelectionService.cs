using AutoMapper;
using Server.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;
using Server.Core.Requests.Selection;
using System.Diagnostics;
using System.Reflection;
using Server.Database;

namespace Server.Services
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
        public async Task<ServiceResponse<List<GetSelectionDto>>> GetAll()
        {
            var response = new ServiceResponse<List<GetSelectionDto>>();
            var dbSelections = await _context.Selections
                .Include(selection => selection.Status)
                .Include(selection => selection.Program)
                .ToListAsync();

            var dbStudents = await _context.Students.ToListAsync();
                
            response.Data = dbSelections.Select(selection => _mapper.Map<GetSelectionDto>(selection)).ToList();
            response.Data.ForEach((selection) => selection.Students = dbStudents
                         .FindAll((student) => student.SelectionId == selection.Id));

            return response;
        }

        public async Task<ServiceResponse<List<GetSelectionStatusDto>>> GetAllSelectionsStatuses()
        {
            return new ServiceResponse<List<GetSelectionStatusDto>>
            {
                Data = await _context.SelectionStatuses
                   .Select(selection => _mapper.Map<GetSelectionStatusDto>(selection))
                   .ToListAsync()
            };
        }

        public async Task<ServiceResponse<GetSelectionDto>> GetById(int id)
        {
            var response = new ServiceResponse<GetSelectionDto>();
            var dbSelection = await _context.Selections
                .Include(selection => selection.Status)
                .Include(selection => selection.Program)
                .FirstOrDefaultAsync(selection => selection.Id == id);

            var dbStudents = await _context.Students.Where(student => student.SelectionId == id).ToListAsync();
            response.Data =  _mapper.Map<GetSelectionDto>(dbSelection);
            response.Data.Students = dbStudents;
            return response;
        }

        public async Task<ServiceResponse<GetSelectionDto>> Remove(RemoveStudentDto removeStudent)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == removeStudent.StudentId && s.SelectionId == removeStudent.SelectionId);
            student.SelectionId = null;
            await _context.SaveChangesAsync();

            return new ServiceResponse<GetSelectionDto>();
        }

        public async Task<ServiceResponse<GetSelectionDto>> Update(int id, UpdateSelectionDto updateSelection)
        {
            ServiceResponse<GetSelectionDto> response = new ServiceResponse<GetSelectionDto>();

            try
            {
                var selection = await _context.Selections
                        .Include(s => s.Status)
                        .Include(s => s.Program)
                        .FirstOrDefaultAsync(s => s.Id == id)
                        ?? throw new Exception("Selection with that id does not exist.");

                var todayDate = DateTime.Now;
                if (todayDate >= updateSelection.StartAt && todayDate < updateSelection.EndAt)
                {
                    selection.SelectionStatusId = 1;
                }
                else selection.SelectionStatusId = 2;


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
