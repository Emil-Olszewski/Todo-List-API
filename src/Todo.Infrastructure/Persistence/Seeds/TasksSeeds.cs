using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Enums;

namespace Todo.Infrastructure.Persistence.Seeds
{
    public static class TasksSeeds
    {
        public static IEnumerable<Task> Get()
        {
            return new List<Task>()
            {
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "I like the way you drive",
                    Description = "You do it like a hive",
                    Priority = Priority.High,
                    EstimatedCompletionTime = DateTime.UtcNow.AddDays(3)
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "I want to hold your mug",
                    Description = "Imagine all the people",
                    Priority = Priority.High,
                    EstimatedCompletionTime = DateTime.UtcNow.AddDays(2)
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "All you need is global domination",
                    Description = "Blue fire engine, blue fire engine",
                    Priority = Priority.High,
                    EstimatedCompletionTime = DateTime.UtcNow.AddDays(5)
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "We all live in our violet coach",
                    Description = "I think you'll understand",
                    Priority = Priority.Medium,
                    EstimatedCompletionTime = DateTime.UtcNow.AddDays(7)
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Above us only poker chips",
                    Description = "But I'm not the only one",
                    Priority = Priority.Medium,
                    EstimatedCompletionTime = DateTime.UtcNow.AddDays(12)
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "You'll let me learn to fly",
                    Description = "Oh yeah!",
                    Priority = Priority.Medium,
                    EstimatedCompletionTime = DateTime.UtcNow.AddDays(15)
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "I never thought I'd see that stick",
                    Description = "And I'm gonna move your key",
                    Priority = Priority.Low,
                    EstimatedCompletionTime = DateTime.UtcNow.AddDays(10)
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "The joystick drops deep as does my light",
                    Description = "Yea, yaz, in a Houston state of mind",
                    Priority = Priority.Low,
                    EstimatedCompletionTime = DateTime.UtcNow.AddDays(7)
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "I never snooze, 'cause to snooze is the husband of site",
                    Description = "In a Houston state of mind",
                    Priority = Priority.Low,
                    EstimatedCompletionTime = DateTime.UtcNow.AddDays(9)
                },
            };
        }
    }
}