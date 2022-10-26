using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;
using Server.Core.Interfaces;
using Server.Core.Requests.Student;
using Server.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class StudentLectureEventsService : IStudentLectureEventsService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public StudentLectureEventsService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetStudentLectureEventsDto>> Get(int studentId, int lectureEventId)
        {
            var response = new ServiceResponse<GetStudentLectureEventsDto>();
            try
            {
                var StudentLectureEvent = await _context.StudentLectureEvents
                   .FirstOrDefaultAsync(sle => sle.LectureEventId == lectureEventId && sle.StudentId == studentId)
                   ?? throw new Exception("Student with that lecture or event id does not exist.");

                response.Data = new GetStudentLectureEventsDto
                {
                    DoneByCandidate = StudentLectureEvent.DoneByCandidate,
                    StatusByCandidate = StudentLectureEvent.StatusByCandidate
                };
                response.Success = true;
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
