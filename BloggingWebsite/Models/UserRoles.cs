namespace BloggingWebsite.Models
{
    public class UserRoles
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public Role? Roles { get; set; }
        public Users? Users { get; set; }
    }
}
