using AutoMapper;
using jap_task.Data;
using jap_task.Dtos.Selection;
using jap_task.Models;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Student;

namespace server.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StudentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetStudentDto>> CreateStudent(AddStudentDto addStudent)
        {
            var selection = await _context.Selections
                .FirstOrDefaultAsync(s => s.Id == addStudent.SelectionId);

            var student = new Student();
            _mapper.Map(addStudent, student);

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<GetStudentDto>();
            serviceResponse.Success = true;
            serviceResponse.Message = "Student is created successfuly.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> DeleteStudent(int id)
        {
            var response = new ServiceResponse<List<GetStudentDto>>();

            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == id)
                ?? throw new Exception("Student with that id does not exist.");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            var dbStudents = await _context.Students
                .Include(student => student.Status)
                .Include(student => student.Selection)
                .ThenInclude(student => student.Program)
                .ToListAsync();

            response.Data = dbStudents.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
            response.Success = true;
            response.Message = "Student is deleted successfuly.";
            return response;
        }
        
        public async Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents()
        {
            var response = new ServiceResponse<List<GetStudentDto>>();
            var dbStudents = await _context.Students
                .Include(student => student.Status)
                .Include(student => student.Selection)
                .ThenInclude(student => student.Program)
                .ToListAsync();

            response.Data = dbStudents.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetStudentDto>> GetStudentById(int id)
        {
            var response = new ServiceResponse<GetStudentDto>();
            try
            {
                var student = await _context.Students
                   .Include(student => student.Status)
                   .Include(student => student.Selection)
                   .ThenInclude(student => student.Program)
                   .FirstOrDefaultAsync(student => student.Id == id)
                   ?? throw new Exception("Student with that id does not exist.");

                response.Data = _mapper.Map<GetStudentDto>(student);
                response.Data.Comments = await _context.Comments
                   .Where(comment => comment.StudentId == id)
                   .ToListAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetStudentDto>> UpdateStudent(int id, UpdateStudentDto updateStudent)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();
            
            try
            {
                var student = await _context.Students
                        .Include(s => s.Status)
                        .FirstOrDefaultAsync(s => s.Id == id)
                        ?? throw new Exception("Student with that id does not exist.");

                var selection = await _context.Selections
                        .Include(s => s.Program)
                        .FirstOrDefaultAsync(s => s.Id == updateStudent.SelectionId)
                        ?? throw new Exception("Selection with that id does not exist.");
               
                var status = await _context.StudentStatuses
                        .FirstOrDefaultAsync(s => s.Id == updateStudent.StudentStatusId)
                        ?? throw new Exception("Student Status with that id does not exist.");
                
                _mapper.Map(updateStudent, student);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetStudentDto>(student);
                response.Success = true;
                response.Message = "Student is edited successfuly.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
