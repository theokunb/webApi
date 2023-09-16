using AutoMapper;
using webApi.Mapper;

namespace webApi.Commands.CreateTask
{
    public class CreateTaskDto : IMapWith<CreateTaskCommand>
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                .ForMember(command => command.Description, option => option.MapFrom(taskDto => taskDto.Description))
                .ForMember(command => command.Header, option => option.MapFrom(taskDto => taskDto.Header))
                .ForMember(command => command.CompletionDate, option => option.MapFrom(taskDto => taskDto.CompletionDate));
        }
    }
}
