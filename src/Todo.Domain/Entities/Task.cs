using System;
using Todo.Domain.Common;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class Task : AuditableEntity
    {       
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime EstimatedCompletionTime { get; set; }
        public bool Completed { get; set; }
    }
}