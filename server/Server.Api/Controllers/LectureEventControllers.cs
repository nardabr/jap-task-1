using Microsoft.AspNetCore.Mvc;
using Server.Core.Interfaces;
using Server.Core.Requests.LectureEvent;
using Server.Services;

namespace Server.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/lecture-event")]
    public class LectureEventControllers : ControllerBase
    {
        private readonly ILectureEventService _lectureEventService;

        public LectureEventControllers(ILectureEventService lectureEventService)
        {
            _lectureEventService = lectureEventService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddLectureEventDto addLectureEvent)
        {
            return Ok(await _lectureEventService.Create(addLectureEvent));
        }

        [HttpPatch]
        public async Task ChangeOrderNumber(ChangeOrderNumberDto changeOrderNumber)
        {
           await _lectureEventService.ChangeOrderNumber(changeOrderNumber);
        }

        [HttpPatch("dates")]
        public async Task GenerateDates(int programId)
        {
            await _lectureEventService.GenerateDates(programId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _lectureEventService.GetById(id));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, UpdateLectureEventDto updateLectureEvent)
        {
            return Ok(await _lectureEventService.Update(id, updateLectureEvent));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _lectureEventService.Delete(id));
        }
    }
}
