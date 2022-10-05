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
    [Route("api/selection")]
    public class SelectionControllers : ControllerBase
    {
        private readonly ISelectionService _selectionService;

        public SelectionControllers(ISelectionService selectionService)
        {
            _selectionService = selectionService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _selectionService.GetAll());
        }
        [HttpGet("GetSelectionsStatuses")]
        public async Task<IActionResult> GetAllSelectionsStatuses()
        {
            return Ok(await _selectionService.GetAllSelectionsStatuses());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _selectionService.GetById(id));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSelectionDto updateSelection)
        {
            return Ok(await _selectionService.Update(id, updateSelection));
        }
        [HttpPatch("removeStudent")]
        public async Task<IActionResult> Remove(RemoveStudentDto removeStudent)
        {
            return Ok(await _selectionService.Remove(removeStudent));
        }
    }
}
