using jap_task.Models;

namespace jap_task.Dtos.Selection
{
    public class GetSelectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public SelectionStatus Status { get; set; }
        public Models.Program Program { get; set; }
        public List<Student> Students { get; set; }
    }
}
