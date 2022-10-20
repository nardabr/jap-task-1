namespace Server.Core.Requests.Comment
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
