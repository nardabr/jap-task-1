using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;
using Server.Core.Interfaces;
using Server.Core.Requests.LectureEvent;
using Server.Core.Requests.Program;
using Server.Core.Requests.Student;
using Server.Database;
using System.Drawing;

namespace Server.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProgramService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetProgramDto>>> GetAll()
        {
            return new ServiceResponse<List<GetProgramDto>>
            {
                Data = await _context.Programs
                   .Select(program => _mapper.Map<GetProgramDto>(program))
                   .ToListAsync()  
            };
        }

        public async Task<ServiceResponse<List<GetLectureEventDto>>> GetProgramDetails(int programId, string? orderBy)
        {
            //var dbLectureEvents = _context.LectureEvents
            //    .AsQueryable();

            //if (orderBy is not null)
            //{
            //    switch (orderBy)
            //    {
            //        case "Type":
            //            dbLectureEvents = dbLectureEvents.OrderBy(le => le.Type);
            //            break;
            //        case "Type desc":
            //            dbLectureEvents = dbLectureEvents.OrderByDescending(le => le.Type);
            //            break;               
            //        case "Name":
            //            dbLectureEvents = dbLectureEvents.OrderBy(le => le.Name);
            //            break;
            //        case "Name desc":
            //            dbLectureEvents = dbLectureEvents.OrderByDescending(le => le.Name);
            //            break;
            //        case "Description":
            //            dbLectureEvents = dbLectureEvents.OrderBy(le => le.Description);
            //            break;
            //        case "Description desc":
            //            dbLectureEvents = dbLectureEvents.OrderByDescending(le => le.Description);
            //            break;
            //        case "Url":
            //            dbLectureEvents = dbLectureEvents.OrderBy(le => le.Url);
            //            break;
            //        case "Url desc":
            //            dbLectureEvents = dbLectureEvents.OrderByDescending(le => le.Url);
            //            break;
            //        case "Work Hours":
            //            dbLectureEvents = dbLectureEvents.OrderBy(le => le.WorkHours);
            //            break;
            //        case "Work Hours desc":
            //            dbLectureEvents = dbLectureEvents.OrderByDescending(le => le.WorkHours);
            //            break;
            //        case "Order Number":
            //            dbLectureEvents = dbLectureEvents.OrderBy(le => le.OrderNumber);
            //            break;
            //        case "Order Number desc":
            //            dbLectureEvents = dbLectureEvents.OrderByDescending(le => le.OrderNumber);
            //            break;
            //        case "Start Date":
            //            dbLectureEvents = dbLectureEvents.OrderBy(le => le.StartDate);
            //            break;
            //        case "Start Date desc":
            //            dbLectureEvents = dbLectureEvents.OrderByDescending(le => le.StartDate);
            //            break;
            //        case "End Date":
            //            dbLectureEvents = dbLectureEvents.OrderBy(le => le.EndDate);
            //            break;
            //        case "EndDate desc":
            //            dbLectureEvents = dbLectureEvents.OrderByDescending(le => le.EndDate);
            //            break;
            //    }
            //}


            return new ServiceResponse<List<GetLectureEventDto>>
            {
                Data = await _context.LectureEvents
                   .Where(le => le.ProgramId == programId)
                   .OrderBy(le => le.OrderNumber)
                   .Select(le => _mapper.Map<GetLectureEventDto>(le))
                   .ToListAsync()
            };
        }
    }
}
