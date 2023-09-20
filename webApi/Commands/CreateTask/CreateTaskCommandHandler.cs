using MediatR;

namespace webApi.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Entities.Task>
    {
        private readonly ITaskDbContext _dbContext;

        public CreateTaskCommandHandler(ITaskDbContext dbContext) => _dbContext = dbContext;

        public async Task<Entities.Task> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Entities.Task
            {
                Header = request.Header,
                Description = request.Description,
                CompleteionDate = request.CompletionDate,
                CreatedDate = DateTime.Now,
                Status = Entities.TaskStatus.Created,
                CompletedDate = DateTime.MaxValue
            };

            await _dbContext.Tasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task;
        }
    }
}
