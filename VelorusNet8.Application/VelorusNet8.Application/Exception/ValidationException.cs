using FluentValidation.Results;


namespace VelorusNet8.Application.Exception;

public class ValidationException : System.Exception
{
    public ValidationException(IEnumerable<ValidationFailure> errors)
        : base("One or more validation failures have occurred.")
    {
        Errors = errors;
    }

    public IEnumerable<ValidationFailure> Errors { get; }
}