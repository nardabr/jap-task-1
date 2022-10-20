using Server.Core.Entities;
using Server.Core.Requests.Selection;

namespace Server.Core.Interfaces
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
