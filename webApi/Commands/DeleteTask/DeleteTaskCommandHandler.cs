using MediatR;
using Microsoft.EntityFrameworkCore;

namespace webApi.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskDbContext _dbContext;

        public DeleteTaskCommandHandler(ITaskDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks.FirstOrDefaultAsync(task => task.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                return;
            }

            _dbContext.Tasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
