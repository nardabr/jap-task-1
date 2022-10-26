using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;
using Server.Core.Helpers;
using Server.Core.Interfaces;
using Server.Core.Requests.LectureEvent;
using Server.Core.Requests.Student;
using Server.Database;

namespace Server.Services
{
    public class LectureEventService : ILectureEventService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public LectureEventService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetLectureEventDto>> Create(AddLectureEventDto addLectureEvent)
        {
            var program = await _context.Programs
                            .FirstOrDefaultAsync(p => p.Id == addLectureEvent.ProgramId);

            var lectureEvents = await _context.LectureEvents
                            .Where((le) => le.ProgramId == addLectureEvent.ProgramId)
                            .ToListAsync();

            var numberOfLectureEvents = lectureEvents.Count;
            numberOfLectureEvents++;

            var lectureEvent = new LectureEvent();
            _mapper.Map(addLectureEvent, lectureEvent);
            lectureEvent.OrderNumber = numberOfLectureEvents;

            _context.LectureEvents.Add(lectureEvent);
            await _context.SaveChangesAsync();

            await GenerateDates(addLectureEvent.ProgramId);

            return new ServiceResponse<GetLectureEventDto>
            {
                Success = true,
                Message = "Lecture/Event is created successfuly."
                //serviceResponse.Data
            };
        }

        public async Task ChangeOrderNumber(ChangeOrderNumberDto changeOrderNumber)
        {
            var lectureEvent = await _context.LectureEvents
                        .FirstOrDefaultAsync(le => le.Id == changeOrderNumber.LectureEventId)
                        ?? throw new Exception("Lecture event with that id does not exist.");

            lectureEvent.OrderNumber = changeOrderNumber.OrderNumber;
            await _context.SaveChangesAsync();
            await GenerateDates(lectureEvent.ProgramId);
        }

        public async Task<ServiceResponse<GetLectureEventDto>> GetById(int id)
        {
            var response = new ServiceResponse<GetLectureEventDto>();
            try
            {
                var lectureEvent = await _context.LectureEvents
                   .FirstOrDefaultAsync(le => le.Id == id)
                   ?? throw new Exception("Lecture or Event with that id does not exist.");

                response.Data = _mapper.Map<GetLectureEventDto>(lectureEvent);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetLectureEventDto>> Update(int id, UpdateLectureEventDto updateLectureEvent)
        {
            ServiceResponse<GetLectureEventDto> response = new ServiceResponse<GetLectureEventDto>();

            try
            {
                var lectureEvent = await _context.LectureEvents
                        .FirstOrDefaultAsync(le => le.Id == id)
                        ?? throw new Exception("Lecture or Event with that id does not exist.");

                _mapper.Map(updateLectureEvent, lectureEvent);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetLectureEventDto>(lectureEvent);
                response.Success = true;
                response.Message = "Edited successfuly.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetLectureEventDto>>> Delete(int id)
        {
            var lectureEvent = await _context.LectureEvents
                .FirstOrDefaultAsync(le => le.Id == id)
                ?? throw new Exception("Lecture or Event with that id does not exist.");

            _context.LectureEvents.Remove(lectureEvent);
            await _context.SaveChangesAsync();

            var lectureEvents = await _context.LectureEvents
                           .Where((le) => le.ProgramId == lectureEvent.ProgramId)
                           .OrderBy(le => le.OrderNumber)
                           .ToListAsync()
           ?? throw new Exception("Lecture or Events with that programId does not exist.");

            for (int i = 0; i < lectureEvents.Count; i++)
            {
                var changeOrderNumber = new ChangeOrderNumberDto
                {
                    LectureEventId = lectureEvents[i].Id,
                    OrderNumber = i + 1,
                };
                await ChangeOrderNumber(changeOrderNumber);
            }

            return new ServiceResponse<List<GetLectureEventDto>>
            {
                Data = lectureEvents.Select(le => _mapper.Map<GetLectureEventDto>(le)).ToList(),
                Success = true,
                Message = "Deleted successfuly."
            };
        }

        public async Task GenerateDates(int programId)
        {
            var selection = await _context.Selections
                 .FirstOrDefaultAsync(s => s.ProgramId == programId)
                 ?? throw new Exception("Selection with that programId does not exist.");

            var lectureEvents = await _context.LectureEvents
                            .Where((le) => le.ProgramId == programId)
                            .OrderBy(le => le.OrderNumber)
                            .ToListAsync()
            ?? throw new Exception("Lecture or Events with that programId does not exist.");

            DateCalculator.CalculateDates(selection.StartAt, lectureEvents);

            await _context.SaveChangesAsync();
        }
    }
}
