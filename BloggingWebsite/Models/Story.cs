using System.ComponentModel.DataAnnotations;

namespace BloggingWebsite.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public int UserId { get; set; }
        [Required]
        [MaxLength(200)]
        public string? StoryTitle { get; set; }
        public string? storyContent { get; set; }
        public string? status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int LikesCount { get; set; }
        public int ReadsCount { get; set; }

        public Users? Users { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<StoryLike>? StoryLikes { get; set; }
    }
}
