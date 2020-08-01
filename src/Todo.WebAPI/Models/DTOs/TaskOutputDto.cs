using System;

namespace Todo.WebAPI.Models.DTOs
{
    /// <summary>
    /// Task Output Data Transfer Object
    /// </summary>
    public class TaskOutputDto
    {
        /// <summary>
        /// Task's Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of task
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description of task
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Task's priority. Possible values: "Low", "Medium" and "High".
        /// </summary>
        public string Priority { get; set; }
        /// <summary>
        /// Until when task should be completed
        /// </summary>
        public DateTime EstimatedCompletionTime { get; set; }
        /// <summary>
        /// Is task done alredy
        /// </summary>
        public bool Completed { get; set; }
    }
}