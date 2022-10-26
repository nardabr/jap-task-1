using Microsoft.AspNetCore.Mvc;
using Server.Core.Interfaces;
using Server.Services;

namespace Server.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/student-lecture-events")]
    public class StudentLectureEventsController : ControllerBase
    {
        private readonly IStudentLectureEventsService _studentLectureEventsService;

        public StudentLectureEventsController(IStudentLectureEventsService studentLectureEventsService)
        {
            _studentLectureEventsService = studentLectureEventsService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(int studentId, int lectureEventId)
        {
            return Ok(await _studentLectureEventsService.Get(studentId, lectureEventId));
        }
    }
}
