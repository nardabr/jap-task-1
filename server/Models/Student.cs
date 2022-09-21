namespace jap_task.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int StudentStatusId { get; set; }
        public StudentStatus? Status { get; set; }
        public int SelectionId { get; set; }
        public Selection? Selection { get; set; }
    }
}
