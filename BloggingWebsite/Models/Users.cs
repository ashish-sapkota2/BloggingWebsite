using System.ComponentModel.DataAnnotations;

namespace BloggingWebsite.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int FollowersCount { get; set; }
        public ICollection<Story>? Stories { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<StoryLike>? StoryLikes { get; set; }
        public ICollection<Follower>? Followers { get; set; }
        public ICollection<Follower>? Following { get; set; }
        public ICollection<UserRoles>? Roles { get; set; }
    }
}
