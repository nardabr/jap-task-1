namespace jap_task.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int StudentId { get; set; }
    }
}
