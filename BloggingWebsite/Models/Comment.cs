namespace BloggingWebsite.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int StoryId { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }

        public string? commentText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Users? Users { get; set; }
        public Story? Story { get; set; }
    }
}
