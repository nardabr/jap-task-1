namespace server.Dtos.Selection
{
    public class UpdateSelectionDto
    {
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int SelectionStatusId { get; set; }
        public int ProgramId { get; set; }
    }
}
