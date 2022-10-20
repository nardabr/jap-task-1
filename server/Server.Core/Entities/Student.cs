namespace Server.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentStatusId { get; set; }
        public StudentStatus Status { get; set; }
        public int? SelectionId { get; set; }
        public Selection Selection { get; set; }
        public int UserId { get; set; }
    }
}
