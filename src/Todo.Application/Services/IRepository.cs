using System;
using Todo.Application.Services.Models;
using Todo.Domain.Entities;

namespace Todo.Application.Services
{
    public interface IRepository
    {
        PagedList<Task> GetAllTasks(ITaskResourceParameters parameters);

        Task GetSingleTask(Guid id);

        void AddTask(Task task);

        void DeleteTask(Task task);

        void SaveChanges();
    }
}