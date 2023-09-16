using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace webApi.Commands.GetTask
{
    public class GetTaskCommandHandler : IRequestHandler<GetTaskCommand, GetTaskViewModel>
    {
        private readonly ITaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskCommandHandler(ITaskDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetTaskViewModel> Handle(GetTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks.FirstOrDefaultAsync(task =>  task.Id == request.Id);

            var res = entity == null ? null : _mapper.Map<GetTaskViewModel>(entity);

            return res;
        }
    }
}
