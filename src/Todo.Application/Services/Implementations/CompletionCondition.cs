using System.Linq;
using Todo.Domain;
using Todo.Domain.Entities;

namespace Todo.Application.Services.Implementations
{
    public class CompletionCondition : ICompletionCondition
    {
        private const string Completed = Constants.CompletionCondition_Completed;
        private const string Uncompleted = Constants.CompletionCondition_Uncompleted;

        public IQueryable<Task> Apply(IQueryable<Task> source, string condition)
        {
            if (PointsToCompleted(condition))
                return source.Where(t => t.Completed == true);

            if (PointsToUncompleted(condition))
                return source.Where(t => t.Completed == false);

            return source;
        }

        public bool IsInvalid(string condition)
        {
            return !(string.IsNullOrWhiteSpace(condition) ||
                PointsToCompleted(condition) || PointsToUncompleted(condition));
        }

        public bool PointsToCompleted(string condition)
        {
            var trimmedCondition = condition.Trim();
            return string.Equals(trimmedCondition, Completed, 
                System.StringComparison.OrdinalIgnoreCase);
        }

        public bool PointsToUncompleted(string condition)
        {
            var trimmedCondition = condition.Trim();
            return string.Equals(trimmedCondition, Uncompleted,
                System.StringComparison.OrdinalIgnoreCase);
        }
    }
}