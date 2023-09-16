using AutoMapper;
using webApi.Mapper;

namespace webApi.Commands.UpdateTask
{
    public class UpdateTaskDto : IMapWith<Entities.Task>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public Entities.TaskStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                .ForMember(command => command.Id, options => options.MapFrom(taskDto => taskDto.Id))
                .ForMember(command => command.Header, options => options.MapFrom(taskDto => taskDto.Header))
                .ForMember(command => command.Description, options => options.MapFrom(taskDto => taskDto.Description))
                .ForMember(command => command.CompletionDate, options => options.MapFrom(taskDto => taskDto.CompletionDate))
                .ForMember(command => command.Status, options => options.MapFrom(taskDto => taskDto.Status));
        }
    }
}
