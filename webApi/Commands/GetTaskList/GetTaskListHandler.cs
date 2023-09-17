using MediatR;
using Microsoft.EntityFrameworkCore;

namespace webApi.Commands.GetTaskList
{
    public class GetTaskListHandler : IRequestHandler<GetTaskListCommand, IEnumerable<Entities.Task>>
    {
        public ITaskDbContext _dbContext;

        public GetTaskListHandler(ITaskDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Entities.Task>> Handle(GetTaskListCommand request, CancellationToken cancellationToken)
        {
            var res = await _dbContext
                    .Tasks
                    .FromSql($"SELECT * FROM Tasks WHERE {request.SerachBy} LIKE '%{request.Pattern}%'")
                    .ToListAsync(cancellationToken);

            res = res.Skip(request.PageSize * request.PageIndex - 1)
                .Take(request.PageSize)
                .ToList();


            return res;
        }
    }
}
