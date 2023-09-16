using MediatR;

namespace webApi.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
