using MediatR;

namespace webApi.Commands.GetTaskList
{
    public class GetTaskListCommand : IRequest<IEnumerable<Entities.Task>>
    {
        public string SerachBy { get; set; }
        public string Pattern { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
