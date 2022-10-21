using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Server.Core.Interfaces;
using Server.Database;
using Server.Core.Requests.Selection;

namespace Server.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/selection")]
    public class SelectionControllers : ControllerBase
    {
        private readonly ISelectionService _selectionService;
        private readonly DataContext _context;

        public SelectionControllers(ISelectionService selectionService, DataContext context)
        {
            _selectionService = selectionService;
            _context = context;
        }
        [HttpGet("GetSelectionsSuccessRates")]
        public async Task<IActionResult> GetSelectionsSuccessRates()
        {
            return Ok(await _context.GetSelectionsSuccessRates.FromSqlInterpolated($"execute dbo.GetSelectionsSuccessRates").ToListAsync());
        }
        [HttpGet("GetOverallSuccessRate")]
        public async Task<IActionResult> GetOverallSuccessRates()
        {
            return Ok(await _context.GetOverallSuccesRate.FromSqlInterpolated($"execute dbo.GetOverallSuccessRates").ToListAsync());
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
