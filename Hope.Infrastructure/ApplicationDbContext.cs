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
        
        // Add DbSet for EmailConfirmationCode entity
        public DbSet<EmailConfirmationCode> EmailConfirmationCodes { get; set; }
        
        // Add DbSets for Missing Person feature
        public DbSet<Center> Centers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<MissingPerson> MissingPersons { get; set; }
        public DbSet<MissingPersonImage> MissingPersonImages { get; set; }
        
        // Add DbSets for Missing Thing feature
        public DbSet<MissingThing> MissingThings { get; set; }
        public DbSet<MissingThingImage> MissingThingImages { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Configure relationships
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Government)
                .WithMany(g => g.Users)
                .HasForeignKey(u => u.GovernmentId)
                .IsRequired(false);
            
            // Configure EmailConfirmationCode entity
            builder.Entity<EmailConfirmationCode>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Configure Missing Person feature entities
            builder.Entity<Report>()
                .HasOne(r => r.Center)
                .WithMany(c => c.Reports)
                .HasForeignKey(r => r.CenterId)
                .OnDelete(DeleteBehavior.Restrict);
                
            builder.Entity<Report>()
                .HasOne(r => r.Government)
                .WithMany()
                .HasForeignKey(r => r.GovernmentId)
                .OnDelete(DeleteBehavior.Restrict);
                
            builder.Entity<Report>()
                .HasOne(r => r.MissingPerson)
                .WithOne(mp => mp.Report)
                .HasForeignKey<MissingPerson>(mp => mp.ReportId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.Entity<MissingPerson>()
                .HasMany(mp => mp.Images)
                .WithOne(i => i.MissingPerson)
                .HasForeignKey(i => i.MissingPersonId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Configure Missing Thing feature entities
            builder.Entity<Report>()
                .HasOne(r => r.MissingThing)
                .WithOne(mt => mt.Report)
                .HasForeignKey<MissingThing>(mt => mt.ReportId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.Entity<MissingThing>()
                .HasMany(mt => mt.Images)
                .WithOne(i => i.MissingThing)
                .HasForeignKey(i => i.MissingThingId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Seed data
            builder.Seed();
        }
    }
}