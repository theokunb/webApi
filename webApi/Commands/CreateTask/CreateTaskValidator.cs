using FluentValidation;

namespace webApi.Commands.CreateTask
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskValidator()
        {
            RuleFor(createTaskCommand => createTaskCommand.Header).NotEmpty().MaximumLength(128);
            RuleFor(createTaskCommand => createTaskCommand.Description).NotEmpty().MaximumLength(1024);
            RuleFor(createTaskCommand => createTaskCommand.CompletionDate).GreaterThan(DateTime.Now);
        }
    }
}
