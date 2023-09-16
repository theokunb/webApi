using Microsoft.EntityFrameworkCore;

namespace webApi
{
    public interface ITaskDbContext
    {
        DbSet<Entities.Task> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
