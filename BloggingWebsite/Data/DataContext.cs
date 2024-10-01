using BloggingWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BloggingWebsite.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options): base(options)
        {

        }

        public DbSet<Users>Users { get; set; }
        public DbSet<Story>Stories { get; set; }
        public DbSet<Comment>Comments { get; set; }
        public DbSet<StoryLike>StoryLikes { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Role>Roles { get; set; }
        public DbSet<UserRoles>UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         

            modelBuilder.Entity<Users>()
                .HasMany(u => u.Stories)
                .WithOne(x => x.Users)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Users>()
                .HasMany(u=>u.Comments)
                .WithOne(c => c.Users)
                .HasForeignKey(c=>c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Users>()
                .HasMany(u => u.StoryLikes)
                .WithOne(sl => sl.Users)
                .HasForeignKey(sl => sl.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //configure blog entity

            modelBuilder.Entity<Story>()
                .HasMany(s => s.StoryLikes)
                .WithOne(sl => sl.Story)
                .HasForeignKey(sl => sl.StoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Story>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.Story)
                .HasForeignKey(c => c.StoryId)
                .OnDelete(DeleteBehavior.Cascade);

            //configure storylike entity
            modelBuilder.Entity<StoryLike>()
                .HasKey(sl => sl.LikeId);

            modelBuilder.Entity<StoryLike>()
                .HasOne(sl => sl.Story)
                .WithMany(s => s.StoryLikes)
                .HasForeignKey(sl => sl.StoryId)
                .OnDelete(DeleteBehavior.NoAction);

            //configure follower entity

            modelBuilder.Entity<Follower>()
                .HasKey(f => f.FollowId);

            modelBuilder.Entity<Follower>()
                .HasOne(f=>f.Followers)
                .WithMany(u=>u.Following)
                .HasForeignKey(f=>f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follower>()
                .HasOne(f => f.Followed)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowedId)
                .OnDelete(DeleteBehavior.Restrict);

            //configure userroles

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.Users)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.Roles)
                .WithMany(r => r.Roles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);


           //comment
            modelBuilder.Entity<Comment>()
                .HasKey(sc => sc.CommentId);

            modelBuilder.Entity<Comment>()
                .HasOne(sc => sc.Story)
                .WithMany(s => s.Comments)
                .HasForeignKey(sc => sc.StoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(sc => sc.Users)
                .WithMany(u => u.Comments) // Assuming Users has a collection of Comments for all types (Blog and Story)
                .HasForeignKey(sc => sc.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }


    }
}
