using jap_task.Dtos.Program;
using jap_task.Models;
using jap_task.Services.ProgramService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace jap_task.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramControllers : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramControllers(IProgramService programService)
        {
            _programService = programService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetProgramDto>>>> Get()
        {
            return Ok(await _programService.GetAllPrograms());
        }
    }
}
