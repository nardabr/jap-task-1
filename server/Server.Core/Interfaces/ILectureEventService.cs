using Server.Core.Entities;
using Server.Core.Requests.LectureEvent;

namespace Server.Core.Interfaces
{
    public interface ILectureEventService
    {
        Task<ServiceResponse<GetLectureEventDto>> Create(AddLectureEventDto addLectureEvent);
        Task<ServiceResponse<GetLectureEventDto>> GetById(int id);
        Task<ServiceResponse<GetLectureEventDto>> Update(int id, UpdateLectureEventDto updateLectureEvent);
        Task<ServiceResponse<List<GetLectureEventDto>>> Delete(int id);
        Task ChangeOrderNumber(ChangeOrderNumberDto changeOrderNumber);
        Task GenerateDates(int programId);
    }
}
