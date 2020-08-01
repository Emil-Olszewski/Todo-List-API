using FluentValidation;

namespace Todo.Infrastructure.FluentValidation.Common
{
    public interface IValidator
    {
    }

    public abstract class Validator<T> : AbstractValidator<T>, IValidator
    {
    }
}