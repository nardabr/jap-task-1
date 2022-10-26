using Microsoft.EntityFrameworkCore;

namespace Server.Core.Entities
{
    public class StudentLectureEvents
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int DoneByCandidate { get; set; }
        public string StatusByCandidate { get; set; }
        public int  LectureEventId{ get; set; }
        public LectureEvent LectureEvent { get; set; }
    }
}
