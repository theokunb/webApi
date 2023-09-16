using MediatR;

namespace webApi.Commands.GetTask
{
    public class GetTaskCommand : IRequest<GetTaskViewModel>
    {
        public int Id { get; set; }
    }
}
