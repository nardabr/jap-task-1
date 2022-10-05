using jap_task.Dtos.Selection;
using jap_task.Models;
using jap_task.Services.ProgramService;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Selection;
using server.Dtos.Student;
using server.Services.StudentService;

namespace server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/student")]
    public class StudentControllers : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentControllers(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string? field, string? searchTerm, string? orderBy, int page, int size)
        {
            return Ok(await _studentService.GetAll(field, searchTerm, orderBy, page, size));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _studentService.GetById(id));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDto updateStudent)
        {
            return Ok(await _studentService.Update(id, updateStudent));
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddStudentDto addStudent)
        {
            return Ok(await _studentService.Create(addStudent));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _studentService.Delete(id));
        }

        [HttpGet("GetStudentStatuses")]
        public async Task<IActionResult> GetAllStudentStatuses()
        {
            return Ok(await _studentService.GetAllStudentStatuses());
        }
    }
}
