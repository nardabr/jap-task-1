using Server.Core.Entities;
using Server.Core.Requests.Program;

namespace Server.Core.Interfaces
{
    public interface IProgramService
    {
        Task<ServiceResponse<List<GetProgramDto>>> GetAll();
    }
}
