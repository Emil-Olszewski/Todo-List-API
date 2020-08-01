using System;

namespace Todo.Infrastructure.FluentValidation.Models
{
    public interface ITaskInputDto
    {
        string Description { get; set; }
        DateTime EstimatedCompletionTime { get; set; }
        string Priority { get; set; }
        string Title { get; set; }
    }
}