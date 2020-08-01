using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Application.Services
{
    public interface IAppDbContext
    {
        DbSet<Task> Tasks { get; set; }

        int SaveChanges();
    }
}