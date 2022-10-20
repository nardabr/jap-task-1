using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Server.Core.Interfaces;

namespace Server.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/program")]
    public class ProgramControllers : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramControllers(IProgramService programService)
        {
            _programService = programService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _programService.GetAll());
        }
    }
}
