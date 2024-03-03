using Microsoft.EntityFrameworkCore;
using SelfHelp.PostgreSql.Tables;

namespace SelfHelp.PostgreSql
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<ChallengeStep> ChallengeSteps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("self_help");
        }
    }
}
