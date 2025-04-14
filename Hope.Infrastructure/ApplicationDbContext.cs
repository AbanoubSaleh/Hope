using Hope.Domain.Entities;
using Hope.Infrastructure.Persistence.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hope.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Government> Governments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Configure relationships
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Government)
                .WithMany(g => g.Users)
                .HasForeignKey(u => u.GovernmentId)
                .IsRequired(false);
            
            // Seed data
            builder.Seed();
        }
    }
}