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
    [Route("api/[controller]")]
    public class StudentControllers : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentControllers(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> Get()
        {
            return Ok(await _studentService.GetAllStudents());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> GetById(int id)
        {
            return Ok(await _studentService.GetStudentById(id));
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> Update(int id, UpdateStudentDto updateStudent)
        {
            return Ok(await _studentService.UpdateStudent(id, updateStudent));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> CreateStudent(AddStudentDto addStudent)
        {
            return Ok(await _studentService.CreateStudent(addStudent));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> Delete(int id)
        {
            return Ok(await _studentService.DeleteStudent(id));
        }

        [HttpGet("GetStudentStatuses")]
        public async Task<ActionResult<ServiceResponse<List<GetStudentStatusDto>>>> GetAllStudentStatuses()
        {
            return Ok(await _studentService.GetAllStudentStatuses());
        }
    }
}
