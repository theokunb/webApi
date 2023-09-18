using MediatR;

namespace webApi.Commands.GetTaskList
{
    public class GetTaskListCommand : IRequest<GetTaskListVm>
    {
        public string SearchBy { get; set; }
        public string Pattern { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
