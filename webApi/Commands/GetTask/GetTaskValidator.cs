using FluentValidation;

namespace webApi.Commands.GetTask
{
    public class GetTaskValidator : AbstractValidator<GetTaskCommand>
    {
        public GetTaskValidator()
        {
            RuleFor(getCommand => getCommand.Id).NotEmpty();
            RuleFor(getCommand => getCommand.Id).Must((val, res) =>
            {
                return int.TryParse(val.Id, out _);
            });
        }
    }
}
