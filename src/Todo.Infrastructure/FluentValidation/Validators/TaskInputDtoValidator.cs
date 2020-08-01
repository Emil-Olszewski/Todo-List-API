using FluentValidation;
using Todo.Domain;
using Todo.Domain.Enums;
using Todo.Infrastructure.FluentValidation.Common;
using Todo.Infrastructure.FluentValidation.Models;

namespace Todo.Infrastructure.FluentValidation.Validators
{
    public class TaskInputDtoValidator : Validator<ITaskInputDto>
    {
        public TaskInputDtoValidator()
        {
            RuleFor(t => t.Title).NotEmpty().Length(
                Constants.TaskInput_Title_MinLength,
                Constants.TaskInput_Title_MaxLength);

            RuleFor(t => t.Description).MaximumLength(
                Constants.TaskInput_Description_MaxLength);

            RuleFor(t => t.EstimatedCompletionTime).NotEmpty();

            RuleFor(t => t.Priority).IsEnumName(typeof(Priority), caseSensitive: false);
        }
    }
}