using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;
using Server.Core.Interfaces;
using Server.Core.Requests.Student;
using System.Collections.Generic;
using Server.Database;


namespace Server.Services
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

        public async Task<ServiceResponse<GetStudentDto>> Create(AddStudentDto addStudent)
        {
            var selection = await _context.Selections
                .FirstOrDefaultAsync(s => s.Id == addStudent.SelectionId);

            var student = new Student();
            _mapper.Map(addStudent, student);

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            
            return new ServiceResponse<GetStudentDto>
            {
                Success = true,
                Message = "Student is created successfuly."
            };
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> Delete(int id)
        {
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

            return new ServiceResponse<List<GetStudentDto>>
            {
                Data = dbStudents.Select(s => _mapper.Map<GetStudentDto>(s)).ToList(),
                Success = true,
                Message = "Student is deleted successfuly."
            };
        }
        
        public async Task<ServiceResponse<List<GetStudentDto>>> GetAll(string? field, string? searchTerm, string? orderBy, int page, int size)
        {

            var response = new ServiceResponse<List<GetStudentDto>>();
            var dbStudents = _context.Students
                .Include(student => student.Status)
                .Include(student => student.Selection)
                .ThenInclude(student => student.Program)
                .AsQueryable();

            if(field is not null)
            {
                switch (field)
                {
                    case "First Name":
                    dbStudents = dbStudents.Where(student => EF.Functions.Like(student.FirstName, $"%{searchTerm}%"));
                        break;

                    case "Last Name":
                    dbStudents = dbStudents.Where(student => EF.Functions.Like(student.LastName, $"%{searchTerm}%"));
                        break;

                    case "Student Status":
                    dbStudents = dbStudents.Where(student => EF.Functions.Like(student.Status.Name, $"%{searchTerm}%"));
                        break;

                    case "Program Info":
                    dbStudents = dbStudents.Where(student => EF.Functions.Like(student.Selection.Program.Name, $"%{searchTerm}%"));
                        break;

                    case "Selections":       
                    dbStudents = dbStudents.Where(student => EF.Functions.Like(student.Selection.Name, $"%{searchTerm}%"));
                        break;
                }
            }

            if (orderBy is not null)
            {
                switch (orderBy)
                {
                    case "First Name":
                        dbStudents = dbStudents.OrderBy(student => student.FirstName);
                        break;
                    case "First Name desc":
                        dbStudents = dbStudents.OrderByDescending(student => student.FirstName);
                        break;

                    case "Last Name":
                        dbStudents = dbStudents.OrderBy(student => student.LastName);
                        break;
                    case "Last Name desc":
                        dbStudents = dbStudents.OrderByDescending(student => student.LastName);
                        break;

                    case "Student Status":
                        dbStudents = dbStudents.OrderBy(student => student.Status.Name);
                        break;
                    case "Student Status desc":
                        dbStudents = dbStudents.OrderByDescending(student => student.Status.Name);
                        break;

                    case "Program Info":
                        dbStudents = dbStudents.OrderBy(student => student.Selection.Program.Name);
                        break;
                    case "Program Info desc":
                        dbStudents = dbStudents.OrderByDescending(student => student.Selection.Program.Name);
                        break;

                    case "Selections":
                        dbStudents = dbStudents.OrderBy(student => student.Selection.Name);
                        break;
                    case "Selections desc":
                        dbStudents = dbStudents.OrderByDescending(student => student.Selection.Name);
                        break;
                }
            }

            double numberOfStudents = dbStudents.Count();
            double pages = Math.Ceiling(numberOfStudents / size);

            dbStudents = dbStudents.Skip((page - 1) * size).Take(size);

            response.Data = await dbStudents.Select(s => _mapper.Map<GetStudentDto>(s)).ToListAsync();
            response.Message = pages.ToString();
            return response;
        }

        public async Task<ServiceResponse<List<GetStudentStatusDto>>> GetAllStudentStatuses()
        {
            return new ServiceResponse<List<GetStudentStatusDto>>
            {
                Data = await _context.StudentStatuses
                   .Select(status => _mapper.Map<GetStudentStatusDto>(status))
                   .ToListAsync()
            };
        }

        public async Task<ServiceResponse<GetStudentDto>> GetById(int id)
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

        public async Task<ServiceResponse<GetStudentDto>> Update(int id, UpdateStudentDto updateStudent)
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
