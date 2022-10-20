using Server.Core.Entities;

namespace Server.Core.Requests.Selection
{
    public class GetSelectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public SelectionStatus Status { get; set; }
        public Entities.Program Program { get; set; }
        public List<Entities.Student> Students { get; set; }
    }
}
