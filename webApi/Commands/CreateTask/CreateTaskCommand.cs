using MediatR;

namespace webApi.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Entities.Task>
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
