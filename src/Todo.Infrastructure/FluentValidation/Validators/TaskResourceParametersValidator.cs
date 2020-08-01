using FluentValidation;
using FluentValidation.Validators;
using Todo.Application.Services;
using Todo.Application.Services.Models;
using Todo.Domain;
using Todo.Infrastructure.FluentValidation.Common;

namespace Todo.Infrastructure.FluentValidation.Validators
{
    public class TaskResourceParametersValidator : Validator<ITaskResourceParameters>
    {
        private readonly ICompletionCondition completionCondition;

        public TaskResourceParametersValidator(ICompletionCondition completionCondition)
        {
            this.completionCondition = completionCondition;

            RuleFor(t => t.TitlePhrase).Length(
                Constants.TaskParameters_TitlePhrase_MinLength,
                Constants.TaskParameters_TitlePhrase_MaxLength);

            RuleFor(t => t.DescriptionPhrase).Length( 
                Constants.TaskParameters_DescriptionPhrase_MinLength,
                Constants.TaskParameters_DescriptionPhrase_MaxLength);

            RuleFor(t => t.CompletionCondition).Custom(ValidCompletionCondition);

            RuleFor(t => t.PageNumber).GreaterThan(0);

            RuleFor(t => t.PageSize).GreaterThan(0);
            RuleFor(t => t.PageSize).LessThanOrEqualTo(Constants.PageSize_Max);
        }

        private void ValidCompletionCondition(string condition, CustomContext context)
        {
            if (completionCondition.IsInvalid(condition))
                context.AddFailure(Constants.CompletionCondition_ErrorTitle, 
                    Constants.CompletionCondition_ErrorMessage);
        }
    }
}