using jap_task.Dtos.Selection;
using jap_task.Models;
using jap_task.Services.SelectionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace jap_task.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SelectionControllers : ControllerBase
    {
        private readonly ISelectionService _selectionService;

        public SelectionControllers(ISelectionService selectionService)
        {
            _selectionService = selectionService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>> Get()
        {
            return Ok(await _selectionService.GetAllSelections());
        }
    }
}
