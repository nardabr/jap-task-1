using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;

namespace Server.Database.Data.Seeders
{
    public static class StudentLectureEventsSeeder
    {
        public static void SeedStudentLectureEvents(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentLectureEvents>().HasData(
                new StudentLectureEvents
                {
                    Id = 1,
                    StudentId = 1, 
                    LectureEventId = 1,
                    DoneByCandidate = 100,
                    StatusByCandidate = "Done"
                },
                new StudentLectureEvents
                {
                    Id = 2,
                    StudentId = 1,
                    LectureEventId = 2,
                    DoneByCandidate = 80,
                    StatusByCandidate = "In Progress"
                },
                new StudentLectureEvents
                {
                    Id = 3,
                    StudentId = 1,
                    LectureEventId = 3,
                    DoneByCandidate = 10,
                    StatusByCandidate = "Started"
                },
                new StudentLectureEvents
                {
                    Id = 4,
                    StudentId = 1,
                    LectureEventId = 4,
                    DoneByCandidate = 0,
                    StatusByCandidate = "Not Started"
                },
                new StudentLectureEvents
                {
                    Id = 5,
                    StudentId = 2,
                    LectureEventId = 5,
                    DoneByCandidate = 100,
                    StatusByCandidate = "Done"
                },
                new StudentLectureEvents
                {
                    Id = 6,
                    StudentId = 2,
                    LectureEventId = 6,
                    DoneByCandidate = 80,
                    StatusByCandidate = "In Progress"
                },
                new StudentLectureEvents
                {
                    Id = 7,
                    StudentId = 2,
                    LectureEventId = 7,
                    DoneByCandidate = 10,
                    StatusByCandidate = "Started"
                },
                new StudentLectureEvents
                {
                    Id = 8,
                    StudentId = 2,
                    LectureEventId = 8,
                    DoneByCandidate = 0,
                    StatusByCandidate = "Not Started"
                },
                new StudentLectureEvents
                {
                    Id = 9,
                    StudentId = 3,
                    LectureEventId = 9,
                    DoneByCandidate = 100,
                    StatusByCandidate = "Done"
                },
                new StudentLectureEvents
                {
                    Id = 10,
                    StudentId = 3,
                    LectureEventId = 10,
                    DoneByCandidate = 80,
                    StatusByCandidate = "In Progress"
                },
                new StudentLectureEvents
                {
                    Id = 11,
                    StudentId = 3,
                    LectureEventId = 11,
                    DoneByCandidate = 10,
                    StatusByCandidate = "Started"
                },
                new StudentLectureEvents
                {
                    Id = 12,
                    StudentId = 3,
                    LectureEventId = 12,
                    DoneByCandidate = 0,
                    StatusByCandidate = "Not Started"
                },
                new StudentLectureEvents
                {
                    Id = 13,
                    StudentId = 4,
                    LectureEventId = 1,
                    DoneByCandidate = 100,
                    StatusByCandidate = "Done"
                },
                new StudentLectureEvents
                { 
                    Id = 14,
                    StudentId = 4,
                    LectureEventId = 2,
                    DoneByCandidate = 80,
                    StatusByCandidate = "In Progress"
                },
                new StudentLectureEvents
                {
                    Id = 15,
                    StudentId = 4,
                    LectureEventId = 3,
                    DoneByCandidate = 10,
                    StatusByCandidate = "Started"
                },
                new StudentLectureEvents
                {
                    Id = 16,
                    StudentId = 4,
                    LectureEventId = 4,
                    DoneByCandidate = 0,
                    StatusByCandidate = "Not Started"
                },
                new StudentLectureEvents
                {
                    Id = 17,
                    StudentId = 5,
                    LectureEventId = 5,
                    DoneByCandidate = 100,
                    StatusByCandidate = "Done"
                },
                new StudentLectureEvents
                {
                    Id = 18,
                    StudentId = 5,
                    LectureEventId = 6,
                    DoneByCandidate = 80,
                    StatusByCandidate = "In Progress"
                },
                new StudentLectureEvents
                {
                    Id = 19,
                    StudentId = 5,
                    LectureEventId = 7,
                    DoneByCandidate = 10,
                    StatusByCandidate = "Started"
                },
                new StudentLectureEvents
                {
                    Id = 20,
                    StudentId = 5,
                    LectureEventId = 8,
                    DoneByCandidate = 0,
                    StatusByCandidate = "Not Started"
                },
                new StudentLectureEvents
                {
                    Id = 21,
                    StudentId = 6,
                    LectureEventId = 9,
                    DoneByCandidate = 100,
                    StatusByCandidate = "Done"
                },
                new StudentLectureEvents
                {
                    Id = 22,
                    StudentId = 6,
                    LectureEventId = 10,
                    DoneByCandidate = 80,
                    StatusByCandidate = "In Progress"
                },
                new StudentLectureEvents
                {
                    Id = 23,
                    StudentId = 6,
                    LectureEventId = 11,
                    DoneByCandidate = 10,
                    StatusByCandidate = "Started"
                },
                new StudentLectureEvents
                {
                    Id = 24,
                    StudentId = 6,
                    LectureEventId = 12,
                    DoneByCandidate = 0,
                    StatusByCandidate = "Not Started"
                },
                new StudentLectureEvents
                {
                    Id = 25,
                    StudentId = 7,
                    LectureEventId = 1,
                    DoneByCandidate = 100,
                    StatusByCandidate = "Done"
                },
                new StudentLectureEvents
                {
                    Id = 26,
                    StudentId = 7,
                    LectureEventId = 2,
                    DoneByCandidate = 80,
                    StatusByCandidate = "In Progress"
                },
                new StudentLectureEvents
                {
                    Id = 27,
                    StudentId = 7,
                    LectureEventId = 3,
                    DoneByCandidate = 10,
                    StatusByCandidate = "Started"
                },
                new StudentLectureEvents
                {
                    Id = 28,
                    StudentId = 7,
                    LectureEventId = 4,
                    DoneByCandidate = 0,
                    StatusByCandidate = "Not Started"
                },
                new StudentLectureEvents
                {
                    Id = 29,
                    StudentId = 8,
                    LectureEventId = 5,
                    DoneByCandidate = 100,
                    StatusByCandidate = "Done"
                },
                new StudentLectureEvents
                {
                    Id = 30,
                    StudentId = 8,
                    LectureEventId = 6,
                    DoneByCandidate = 80,
                    StatusByCandidate = "In Progress"
                },
                new StudentLectureEvents
                {
                    Id = 31,
                    StudentId = 8,
                    LectureEventId = 7,
                    DoneByCandidate = 10,
                    StatusByCandidate = "Started"
                },
                new StudentLectureEvents
                {
                    Id = 32,
                    StudentId = 8,
                    LectureEventId = 8,
                    DoneByCandidate = 0,
                    StatusByCandidate = "Not Started"
                },
                new StudentLectureEvents
                {
                    Id = 33,
                    StudentId = 9,
                    LectureEventId = 9,
                    DoneByCandidate = 100,
                    StatusByCandidate = "Done"
                },
                new StudentLectureEvents
                {
                    Id = 34,
                    StudentId = 9,
                    LectureEventId = 10,
                    DoneByCandidate = 80,
                    StatusByCandidate = "In Progress"
                },
                new StudentLectureEvents
                {
                    Id = 35,
                    StudentId = 9,
                    LectureEventId = 11,
                    DoneByCandidate = 10,
                    StatusByCandidate = "Started"
                },
                new StudentLectureEvents
                {
                    Id = 36,
                    StudentId = 9,
                    LectureEventId = 12,
                    DoneByCandidate = 0,
                    StatusByCandidate = "Not Started"
                },
                 new StudentLectureEvents
                 {
                     Id = 37,
                     StudentId = 10,
                     LectureEventId = 1,
                     DoneByCandidate = 100,
                     StatusByCandidate = "Done"
                 },
                new StudentLectureEvents
                {
                    Id = 38,
                    StudentId = 10,
                    LectureEventId = 2,
                    DoneByCandidate = 80,
                    StatusByCandidate = "In Progress"
                },
                new StudentLectureEvents
                { 
                    Id = 39,
                    StudentId = 10,
                    LectureEventId = 3,
                    DoneByCandidate = 10,
                    StatusByCandidate = "Started"
                },
                new StudentLectureEvents
                {
                    Id = 40,
                    StudentId = 10,
                    LectureEventId = 4,
                    DoneByCandidate = 0,
                    StatusByCandidate = "Not Started"
                }
                );;
        }
    }
}
