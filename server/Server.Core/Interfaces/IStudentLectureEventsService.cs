using Server.Core.Entities;
using Server.Core.Requests.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Interfaces
{
    public interface IStudentLectureEventsService
    {
        Task<ServiceResponse<GetStudentLectureEventsDto>> Get(int studentId, int lectureEventId);
    }
}
