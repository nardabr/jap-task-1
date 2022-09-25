using jap_task.Models;
using server.Dtos.Selection;
using server.Dtos.Student;

namespace server.Services.StudentService
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents();
        Task<ServiceResponse<List<GetStudentStatusDto>>> GetAllStudentStatuses();
        Task<ServiceResponse<GetStudentDto>> GetStudentById(int id);
        Task<ServiceResponse<GetStudentDto>> UpdateStudent(int id, UpdateStudentDto updateStudent);
        Task<ServiceResponse<GetStudentDto>> CreateStudent(AddStudentDto addStudent);
        Task<ServiceResponse<List<GetStudentDto>>> DeleteStudent(int id);
    }
}
