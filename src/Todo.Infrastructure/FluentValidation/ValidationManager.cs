using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using Todo.Application.Services;
using Todo.Infrastructure.FluentValidation.Common;
using Todo.Infrastructure.FluentValidation.Validators;

namespace Todo.Infrastructure.FluentValidation
{
    public class ValidationManager : IValidationManager
    {
        private readonly List<IValidator> validators;

        public ValidationManager(ICompletionCondition completionCondition)
        {
            validators = new List<IValidator>
            {
                new TaskResourceParametersValidator(completionCondition),
                new TaskInputDtoValidator()
            };
        }

        public bool IsInvalid<T>(T input, ModelStateDictionary modelState = null)
        {
            var validator = validators.OfType<Validator<T>>().FirstOrDefault();
            if (validator is null)
                return false;

            var validationResult = validator.Validate(input);
            if (validationResult.IsValid)
                return false;

            if (modelState != null)
                validationResult.AddToModelState(modelState, null);

            return true;
        }
    }
}