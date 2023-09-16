using Microsoft.EntityFrameworkCore;
using webApi.EntityTypeConfiguration;

namespace webApi
{
    public class TaskDbContext : DbContext, ITaskDbContext
    {
        public DbSet<Entities.Task> Tasks { get; set; }

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DbInitializer
    {
        public static void Initialize(DbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
