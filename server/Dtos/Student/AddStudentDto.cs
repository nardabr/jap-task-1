namespace server.Dtos.Student
{
    public class AddStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int StudentStatusId { get; set; }
        public int SelectionId { get; set; }
        public int UserId { get; set; }
    }
}
