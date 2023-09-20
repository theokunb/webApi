using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using webApi.Commands.CreateTask;
using webApi.Commands.DeleteTask;
using webApi.Commands.GetTask;
using webApi.Commands.GetTaskList;
using webApi.Commands.UpdateTask;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TasksController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Create([FromBody] CreateTaskDto taskDto, CreateTaskValidator validator)
        {
            var command = _mapper.Map<CreateTaskCommand>(taskDto);

            var result = await validator.ValidateAsync(command);

            if (result.IsValid == false)
            {
                return;
            }

            await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] UpdateTaskDto taskDto, UpdateTaskValidator validator)
        {
            var command = _mapper.Map<UpdateTaskCommand>(taskDto);

            var result = await validator.ValidateAsync(command);

            if (result.IsValid == false)
            {
                return default;
            }

            await _mediator.Send(command);

            return command.Id;
        }

        [HttpDelete]
        public async Task<int> Delete([AsParameters] int id, DeleteTaskValidator validator)
        {
            var command = new DeleteTaskCommand { Id = id };

            var result = await validator.ValidateAsync(command);

            if (result.IsValid == false)
            {
                return default;
            }

            await _mediator.Send(command);

            return 0;
        }

        [HttpGet("{id}")]
        public async Task<GetTaskViewModel> Get([AsParameters] int id, GetTaskValidator validator)
        {
            var command = new GetTaskCommand { Id = id };
            var result = await validator.ValidateAsync(command);

            if (result.IsValid == false)
            {
                return default;
            }

            var taskVm = await _mediator.Send(command);

            return taskVm;
        }

        [HttpGet]
        public async Task<GetTaskListVm> Get([AsParameters] string searchBy, string pattern, int pageIndex, int pageSize, GetTaskListValidator validator)
        {
            var command = new GetTaskListCommand
            {
                SearchBy = searchBy,
                Pattern = pattern,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var result = await validator.ValidateAsync(command);

            if (result.IsValid == false)
            {
                return default;
            }

            var res = await _mediator.Send(command);

            return res;
        }
    }
}