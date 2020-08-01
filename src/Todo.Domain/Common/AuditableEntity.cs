using System;

namespace Todo.Domain.Common
{
    public class AuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}