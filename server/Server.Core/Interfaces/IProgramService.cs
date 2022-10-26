using Server.Core.Entities;
using Server.Core.Requests.LectureEvent;
using Server.Core.Requests.Program;

namespace Server.Core.Interfaces
{
    public interface IProgramService
    {
        Task<ServiceResponse<List<GetProgramDto>>> GetAll();

        Task<ServiceResponse<List<GetLectureEventDto>>> GetProgramDetails(int programId, string? orderBy);
    }
}
