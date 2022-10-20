using Server.Core.Entities;
using Server.Core.Requests.Student;

namespace Server.Core.Interfaces
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<GetStudentDto>>> GetAll(string? field, string? searchTerm, string? orderBy, int page, int size);
        Task<ServiceResponse<List<GetStudentStatusDto>>> GetAllStudentStatuses();
        Task<ServiceResponse<GetStudentDto>> GetById(int id);
        Task<ServiceResponse<GetStudentDto>> Update(int id, UpdateStudentDto updateStudent);
        Task<ServiceResponse<GetStudentDto>> Create(AddStudentDto addStudent);
        Task<ServiceResponse<List<GetStudentDto>>> Delete(int id);
    }
}
