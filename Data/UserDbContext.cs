using Microsoft.EntityFrameworkCore;
using TicTacToe.Model;

namespace TicTacToe.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> option) : base(option)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
            });
            
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasIndex(e => e.MatchId).IsUnique();
            });     
        }
    }
}
