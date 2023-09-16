using FluentValidation;

namespace webApi.Commands.UpdateTask
{
    public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskValidator() 
        {
            RuleFor(updateCommand => updateCommand.Id).NotEmpty();
            RuleFor(updateCommand => updateCommand.Header).MaximumLength(128);
            RuleFor(updateCommand => updateCommand.Description).MaximumLength(1024);
            RuleFor(updateCommand => updateCommand.CompletionDate).GreaterThan(DateTime.Now);
            RuleFor(updateCommand => updateCommand.Status).NotEmpty();
        }
    }
}
