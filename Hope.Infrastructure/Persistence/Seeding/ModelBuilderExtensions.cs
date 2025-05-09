using Microsoft.EntityFrameworkCore;

namespace Hope.Infrastructure.Persistence.Seeding
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedGovernments();
            modelBuilder.SeedCenters();
        }
    }
}