namespace Server.Core.Requests.Student
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Entities.StudentStatus Status { get; set; }
        public Entities.Selection Selection { get; set; }
        public List<Entities.Comment> Comments { get; set; }

    }
}
