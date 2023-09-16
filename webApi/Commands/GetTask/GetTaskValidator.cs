using FluentValidation;

namespace webApi.Commands.GetTask
{
    public class GetTaskValidator : AbstractValidator<GetTaskCommand>
    {
        public GetTaskValidator()
        {
            RuleFor(getCommand => getCommand.Id).NotEmpty();
        }
    }
}
