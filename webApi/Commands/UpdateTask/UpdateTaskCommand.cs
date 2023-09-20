using MediatR;

namespace webApi.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<Entities.Task>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public Entities.TaskStatus Status { get; set; }
    }
}
