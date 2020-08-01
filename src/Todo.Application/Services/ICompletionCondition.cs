using System.Linq;
using Todo.Domain.Entities;

namespace Todo.Application.Services
{
    public interface ICompletionCondition
    {
        IQueryable<Task> Apply(IQueryable<Task> source, string condition);

        bool IsInvalid(string condition);
    }
}