using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Entities
{

    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Questions)
                .WithOne(x => x.User)
                .HasPrincipalKey(x => x.UserId);
        }
    }
}