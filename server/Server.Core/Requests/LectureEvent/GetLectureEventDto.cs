namespace Server.Core.Requests.LectureEvent
{
    public class GetLectureEventDto
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int WorkHours { get; set; }
        public int OrderNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
