using jap_task.Dtos.Selection;
using jap_task.Models;
using server.Dtos.Selection;

namespace jap_task.Services.SelectionService
{
    public interface ISelectionService
    {
        Task<ServiceResponse<List<GetSelectionDto>>> GetAllSelections();
        Task<ServiceResponse<GetSelectionDto>> GetSelectionById(int id);
        Task<ServiceResponse<GetSelectionDto>> UpdateSelection(int id, UpdateSelectionDto updateSelection);
        Task<ServiceResponse<List<GetSelectionStatusDto>>> GetAllSelectionsStatus();
        Task<ServiceResponse<GetSelectionDto>> RemoveStudent(RemoveStudentDto removeStudent);
    }
}
