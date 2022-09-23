
namespace server.Dtos.Student
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public jap_task.Models.StudentStatus Status { get; set; }
        public jap_task.Models.Selection Selection { get; set; }
        public List<jap_task.Models.Comment> Comments { get; set; }

    }
}
