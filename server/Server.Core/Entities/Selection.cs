namespace Server.Core.Entities
{
    public class Selection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int SelectionStatusId { get; set; }
        public SelectionStatus Status { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; } 
    }
}
