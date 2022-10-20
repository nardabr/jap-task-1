namespace Server.Core.Requests.Student
{
    public class UpdateStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? StudentStatusId { get; set; }
        public int? SelectionId { get; set; }

    }
}
