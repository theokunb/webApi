using MediatR;

namespace webApi.Commands.GetTask
{
    public class GetTaskCommand : IRequest<GetTaskViewModel>
    {
        public string Id { get; set; }
    }
}
