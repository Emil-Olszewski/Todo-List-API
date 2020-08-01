using System;
using System.ComponentModel.DataAnnotations;
using Todo.Domain;
using Todo.Infrastructure.FluentValidation.Models;
namespace Todo.WebAPI.Models.DTOs
{
    /// <summary>
    /// Task Input Data Transfer Object
    /// </summary>
    public class TaskInputDto : ITaskInputDto
    {
        /// <summary>
        /// Title
        /// </summary>
        [Required]
        [MinLength(Constants.TaskInput_Title_MinLength)]
        [MaxLength(Constants.TaskInput_Title_MaxLength)]
        public string Title { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [MaxLength(Constants.TaskInput_Description_MaxLength)]
        public string Description { get; set; }
        /// <summary>
        /// Priority: "Low", "Medium", "High"
        /// </summary>
        [Required]
        public string Priority { get; set; }
        /// <summary>
        /// Until when you'd like to finish your task
        /// </summary>
        [Required]
        public DateTime EstimatedCompletionTime { get; set; }
        /// <summary>
        /// Maybe you already completed it
        /// </summary>
        public bool Completed { get; set; }
    }
}