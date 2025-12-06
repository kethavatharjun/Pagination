using Microsoft.EntityFrameworkCore;
using onetoneRelationship.Models;
namespace onetoneRelationship
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-one relationship between User and UserProfile with referential integrity
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade) // On delete: cascade
                .IsRequired();

            // Set referential integrity for update (EF Core uses cascade by default for PK updates)
            // No explicit OnUpdate in EF Core, handled by database if PK is updated

            base.OnModelCreating(modelBuilder);
        }
    }
}
