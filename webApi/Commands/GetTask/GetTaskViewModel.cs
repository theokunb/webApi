using AutoMapper;
using webApi.Mapper;

namespace webApi.Commands.GetTask
{
    public class GetTaskViewModel : IMapWith<Entities.Task>
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public Entities.TaskStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Task, GetTaskViewModel>()
                .ForMember(taskVm => taskVm.Header, option => option.MapFrom(task => task.Header))
                .ForMember(taskVm => taskVm.Description, option => option.MapFrom(task => task.Description))
                .ForMember(taskVm => taskVm.CompletionDate, option => option.MapFrom(task => task.CompleteionDate))
                .ForMember(taskVm => taskVm.CreatedDate, option => option.MapFrom(task => task.CreatedDate))
                .ForMember(taskVm => taskVm.CompletedDate, option => option.MapFrom(task => task.CompletedDate))
                .ForMember(taskVm => taskVm.Status, option => option.MapFrom(task => task.Status));
        }
    }
}
