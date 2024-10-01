namespace BloggingWebsite.Models
{
    public class StoryLike
    {
        public int LikeId { get; set; }
        public int StoryId { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Story? Story { get; set; }
        public Users? Users { get; set; }
    }
}
