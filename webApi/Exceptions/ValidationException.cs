using FluentValidation.Results;

namespace webApi.Exceptions
{
    public class ValidationException : Exception
    {
        public List<ValidationFailure> Errors { get; set; }

        public ValidationException(List<ValidationFailure> errors) => Errors = errors;
    }
}
