using Microsoft.EntityFrameworkCore;

namespace FitnessCalendar.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<FitnessRecord> FitnessRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Добавляем предопределенные типы тренировок
            modelBuilder.Entity<TrainingType>().HasData(
                new TrainingType { Id = 1, Name = "FullBody", Description = "Тренировка всего тела" },
                new TrainingType { Id = 2, Name = "Stretching", Description = "Растяжка" }
            );
        }
    }
} 