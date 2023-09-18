namespace webApi.Commands.GetTaskList
{
    public class GetTaskListVm
    {
        public IEnumerable<Entities.Task> Tasks { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex * PageSize < TotalCount;
        public double PagesCount => Math.Ceiling((float)TotalCount / PageSize);
    }
}
