﻿using MediatR;
using Microsoft.EntityFrameworkCore;

namespace webApi.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskDbContext _dbContext;

        public UpdateTaskCommandHandler(ITaskDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks.FirstOrDefaultAsync(task => task.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                return;
            }

            entity.Header = request.Header;
            entity.Description = request.Description;
            entity.CompleteionDate = request.CompletionDate;
            entity.Status = request.Status;

            if(request.Status == Entities.TaskStatus.Completed)
            {
                entity.CompletedDate = DateTime.Now;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
