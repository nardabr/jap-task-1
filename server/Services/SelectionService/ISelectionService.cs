using jap_task.Dtos.Selection;
using jap_task.Models;

namespace jap_task.Services.SelectionService
{
    public interface ISelectionService
    {
        Task<ServiceResponse<List<GetSelectionDto>>> GetAllSelections();
    }
}
