namespace BloggingWebsite.Models
{
    public class Follower
    {
        public int FollowId { get; set; }

        public int FollowerId { get; set; }
        public int FollowedId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Users? Followers { get; set; }
        public Users? Followed { get; set; }

    }
}
