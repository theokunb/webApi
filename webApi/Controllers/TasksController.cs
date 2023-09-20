using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using webApi.Commands.CreateTask;
using webApi.Commands.DeleteTask;
using webApi.Commands.GetTask;
using webApi.Commands.GetTaskList;
using webApi.Commands.UpdateTask;
using webApi.Exceptions;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<Entities.Task> Create([FromBody] CreateTaskDto taskDto, CreateTaskValidator validator)
        {
            var command = _mapper.Map<CreateTaskCommand>(taskDto);
            var validationRes = await validator.ValidateAsync(command);

            if (validationRes.IsValid == false)
            {
                throw new ValidationException(validationRes.Errors);
            }

            var createdEntity = await _mediator.Send(command);
            return createdEntity;
        }

        [HttpPut]
        public async Task<Entities.Task> Update([FromBody] UpdateTaskDto taskDto, UpdateTaskValidator validator)
        {
            var command = _mapper.Map<UpdateTaskCommand>(taskDto);
            var validationRes = await validator.ValidateAsync(command);

            if (validationRes.IsValid == false)
            {
                throw new ValidationException(validationRes.Errors);
            }

            var updatedEntity = await _mediator.Send(command);
            return updatedEntity;
        }

        [HttpDelete]
        public async Task<int> Delete([AsParameters] int id, DeleteTaskValidator validator)
        {
            var command = new DeleteTaskCommand { Id = id };
            var validationRes = await validator.ValidateAsync(command);

            if (validationRes.IsValid == false)
            {
                throw new ValidationException(validationRes.Errors);
            }

            await _mediator.Send(command);

            return id;
        }

        [HttpGet("{id}")]
        public async Task<GetTaskViewModel> Get([AsParameters] string id, GetTaskValidator validator)
        {
            var command = new GetTaskCommand { Id = id };
            var validationRes = await validator.ValidateAsync(command);

            if (validationRes.IsValid == false)
            {
                throw new ValidationException(validationRes.Errors);
            }

            var taskVm = await _mediator.Send(command);

            return taskVm;
        }

        [HttpGet]
        public async Task<GetTaskListVm> Get([AsParameters]int pageIndex, int pageSize, GetTaskListValidator validator, string pattern = "", string searchBy = "")
        {
            var command = new GetTaskListCommand
            {
                SearchBy = searchBy,
                Pattern = pattern,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var validationRes = await validator.ValidateAsync(command);

            if (validationRes.IsValid == false)
            {
                throw new ValidationException(validationRes.Errors);
            }

            var res = await _mediator.Send(command);

            return res;
        }
    }
}