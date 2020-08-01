using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Todo.Infrastructure.FluentValidation
{
    public interface IValidationManager
    {
        bool IsInvalid<T>(T input, ModelStateDictionary modelState = null);
    }
}