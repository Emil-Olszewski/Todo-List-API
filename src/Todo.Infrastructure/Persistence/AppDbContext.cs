using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using Todo.Application.Services;
using Todo.Domain.Common;
using Todo.Domain.Entities;
using Todo.Infrastructure.Persistence.Seeds;

namespace Todo.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData(TasksSeeds.Get());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
                SetValidDates(entry);

            return base.SaveChanges();
        }

        private static void SetValidDates(EntityEntry<AuditableEntity> entry)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    if (new DateTime(1, 1, 1, 0, 0, 0) >= entry.Entity.Created)
                        entry.Entity.Created = DateTime.UtcNow;
                    entry.Entity.Modified = entry.Entity.Created;
                    break;

                case EntityState.Modified:
                    entry.Entity.Modified = DateTime.UtcNow;
                    break;
            }
        }
    }
}