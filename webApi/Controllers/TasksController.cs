using AutoMapper;
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
        public async Task<IResult> Create([FromBody] CreateTaskDto taskDto, CreateTaskValidator validator)
        {
            var command = _mapper.Map<CreateTaskCommand>(taskDto);
            var validationRes = await validator.ValidateAsync(command);

            if (validationRes.IsValid == false)
            {
                return Results.BadRequest(validationRes.Errors);
            }

            var createdEntity = await _mediator.Send(command);
            return Results.Ok(createdEntity);
        }

        [HttpPut]
        public async Task<IResult> Update([FromBody] UpdateTaskDto taskDto, UpdateTaskValidator validator)
        {
            var command = _mapper.Map<UpdateTaskCommand>(taskDto);
            var validationRes = await validator.ValidateAsync(command);

            if (validationRes.IsValid == false)
            {
                Results.BadRequest(validationRes.Errors);
            }

            var updatedEntity = await _mediator.Send(command);
            return Results.Ok(updatedEntity);
        }

        [HttpDelete]
        public async Task<IResult> Delete([AsParameters] int id, DeleteTaskValidator validator)
        {
            var command = new DeleteTaskCommand { Id = id };
            var validationRes = await validator.ValidateAsync(command);

            if (validationRes.IsValid == false)
            {
                Results.BadRequest(validationRes.Errors);
            }

            await _mediator.Send(command);

            return Results.Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get([AsParameters] string id, GetTaskValidator validator)
        {
            var command = new GetTaskCommand { Id = id };
            var validationRes = await validator.ValidateAsync(command);

            if (validationRes.IsValid == false)
            {
                return Results.BadRequest(validationRes.Errors);
            }

            var taskVm = await _mediator.Send(command);

            return Results.Ok(taskVm);
        }

        [HttpGet]
        public async Task<IResult> Get([AsParameters]int pageIndex, int pageSize, GetTaskListValidator validator, string pattern = "", string searchBy = "")
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
                return Results.BadRequest(validationRes.Errors);
            }

            var res = await _mediator.Send(command);

            return Results.Ok(res);
        }
    }
}