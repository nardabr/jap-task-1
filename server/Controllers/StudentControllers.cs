using jap_task.Data;
using jap_task.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Student;
using server.Services.MailService;
using server.Services.StudentService;

namespace server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/student")]
    public class StudentControllers : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IAuthRepository _authRepo;
        private readonly IMailService _mailService;

        public StudentControllers(IStudentService studentService, IAuthRepository authRepo, IMailService mailService)
        {
            _studentService = studentService;
            _authRepo = authRepo;
            _mailService = mailService;
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
            var user = new UserInsertRequest
            {
                Username = addStudent.FirstName.ToLower() + addStudent.LastName.ToLower(),
                Email = addStudent.Email,
                Password = "Password123$",
                ConfirmPassword = "Password123$", 
                RoleId = 2,
            };

            var createdUser = await _authRepo.InsertUser(user);
            addStudent.UserId = createdUser.Id;

            await _mailService.SendEmailAsync(addStudent.Email, "Welcome new user", "Hey!, new user this is your password for login : Password123$ ");

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
