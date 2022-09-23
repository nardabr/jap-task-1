using jap_task.Dtos.Selection;
using jap_task.Models;
using jap_task.Services.SelectionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using server.Dtos.Student;
using server.Dtos.Selection;

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
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSelectionDto>>> GetById(int id)
        {
            return Ok(await _selectionService.GetSelectionById(id));
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSelectionDto>>> Update(int id, UpdateSelectionDto updateSelection)
        {
            return Ok(await _selectionService.UpdateSelection(id, updateSelection));
        }
    }
}
