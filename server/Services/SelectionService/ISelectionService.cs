using jap_task.Dtos.Selection;
using jap_task.Models;
using server.Dtos.Selection;

namespace jap_task.Services.SelectionService
{
    public interface ISelectionService
    {
        Task<ServiceResponse<List<GetSelectionDto>>> GetAll();
        Task<ServiceResponse<GetSelectionDto>> GetById(int id);
        Task<ServiceResponse<GetSelectionDto>> Update(int id, UpdateSelectionDto updateSelection);
        Task<ServiceResponse<List<GetSelectionStatusDto>>> GetAllSelectionsStatuses();
        Task<ServiceResponse<GetSelectionDto>> Remove(RemoveStudentDto removeStudent);
    }
}
