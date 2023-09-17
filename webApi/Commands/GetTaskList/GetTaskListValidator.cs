using FluentValidation;

namespace webApi.Commands.GetTaskList
{
    public class GetTaskListValidator : AbstractValidator<GetTaskListCommand>
    {
        public GetTaskListValidator() 
        {
            RuleFor(command => command.SerachBy).NotEmpty();
            RuleFor(command => command.Pattern).NotEmpty();
            RuleFor(command => command.PageIndex).NotEmpty();
            RuleFor(command => command.PageSize).NotEmpty();
        }
    }
}
