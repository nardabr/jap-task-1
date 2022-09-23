namespace server.Dtos.Comment
{
    public class CreateCommentDto
    {
        public string Text { get; set; }
        public int? StudentId { get; set; }
    }
}
