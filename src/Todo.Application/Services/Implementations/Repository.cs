using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Todo.Application.Services.Models;
using Todo.Domain.Entities;

namespace Todo.Application.Services.Implementations
{
    public class Repository : IRepository
    {
        private readonly IAppDbContext context;
        private readonly ICompletionCondition completionCondition;

        public Repository(IAppDbContext context, ICompletionCondition completionCondition)
        {
            this.context = context;
            this.completionCondition = completionCondition;
        }

        public PagedList<Task> GetAllTasks(ITaskResourceParameters parameters)
        {
            var tasks = context.Tasks.AsNoTracking();

            tasks = ApplyParameters(parameters, tasks);

            tasks = tasks.OrderByDescending(t => t.Priority);

            return PagedList<Task>.Create(tasks, parameters.PageNumber, parameters.PageSize);
        }

        private IQueryable<Task> ApplyParameters(ITaskResourceParameters parameters, IQueryable<Task> tasks)
        {
            if (!string.IsNullOrWhiteSpace(parameters.TitlePhrase))
            {
                string likePhrase = $"%{parameters.TitlePhrase}%";
                tasks = tasks.Where(t => EF.Functions.Like(t.Title, likePhrase));
            }

            if (!string.IsNullOrWhiteSpace(parameters.DescriptionPhrase))
            {
                string likePhrase = $"%{parameters.DescriptionPhrase}%";
                tasks = tasks.Where(t => EF.Functions.Like(t.Description, likePhrase));
            }

            if (!string.IsNullOrWhiteSpace(parameters.CompletionCondition))
                tasks = completionCondition.Apply(tasks, parameters.CompletionCondition);

            return tasks;
        }

        public Task GetSingleTask(Guid id)
        {
            return context.Tasks.Find(id);
        }

        public void AddTask(Task task)
        {
            context.Tasks.Add(task);
        }

        public void DeleteTask(Task task)
        {
            context.Tasks.Remove(task);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}