using jap_task.Dtos.Program;
using jap_task.Models;

namespace jap_task.Services.ProgramService
{
    public interface IProgramService
    {
        Task<ServiceResponse<List<GetProgramDto>>> GetAllPrograms();
    }
}
