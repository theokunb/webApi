using FluentValidation;

namespace webApi.Commands.DeleteTask
{
    public class DeleteTaskValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskValidator() 
        {
            RuleFor(deleteCommand => deleteCommand.Id).GreaterThan(0);
        }
    }
}
