using MediatR;
using Microsoft.EntityFrameworkCore;

namespace webApi.Commands.GetTaskList
{
    public class GetTaskListHandler : IRequestHandler<GetTaskListCommand, GetTaskListVm>
    {
        public ITaskDbContext _dbContext;

        public GetTaskListHandler(ITaskDbContext dbContext) => _dbContext = dbContext;

        public async Task<GetTaskListVm> Handle(GetTaskListCommand request, CancellationToken cancellationToken)
        {
            var res = await _dbContext
                    .Tasks
                    .ToListAsync(cancellationToken);

            Filtrator filtrator = new(request.SearchBy, request.Pattern);
            var filteredRes = filtrator.Filter(res);

            var pagedRes = filteredRes.Skip(request.PageSize * (request.PageIndex - 1))
                .Take(request.PageSize)
                .ToList();

            var vm = new GetTaskListVm
            {
                Tasks = pagedRes,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                TotalCount = filteredRes.Count()
            };

            return vm;
        }
    }
}
