namespace Server.Core.Requests.Comment
{
    public class CreateCommentDto
    {
        public string Text { get; set; }
        public int? StudentId { get; set; }
    }
}
