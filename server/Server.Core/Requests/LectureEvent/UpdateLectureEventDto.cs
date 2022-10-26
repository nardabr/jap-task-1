namespace Server.Core.Requests.LectureEvent
{
    public class UpdateLectureEventDto
    {
        public int ProgramId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int WorkHours { get; set; }
    }
}
