using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Todo.Application.Services;
using Todo.Application.Services.Models;
using Todo.Domain.Entities;
using Todo.Infrastructure.FluentValidation.Models;
using Todo.WebAPI.Helpers;
using Todo.WebAPI.Models.DTOs;
using Todo.WebAPI.ResourceParameters;
using ControllerBase = Todo.WebAPI.Controllers.Common.ControllerBase;

namespace Todo.WebAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class TasksController : ControllerBase
    {
        public TasksController(IRepository repository, IControllerServices services)
            : base(repository, services)
        {
        }

        /// <summary>
        /// Get a set of available operations 
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
            return Ok();
        }

        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns></returns>
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(Name = "GetTasks")]
        public ActionResult<IEnumerable<PagedList<TaskOutputDto>>> GetAll
            ([FromQuery] TaskResourceParameters parameters)
        {
            if (AreInvalid(parameters))
                return ValidationProblem(ModelState);

            var tasksFromRepo = repository.GetAllTasks(parameters);
            var mappedTasks = services.Map<IEnumerable<TaskOutputDto>>(tasksFromRepo);

            AddPaginationHeader(tasksFromRepo);

            return Ok(mappedTasks);
        }

        private bool AreInvalid(TaskResourceParameters parameters)
        {
            return services.IsInvalid(parameters as ITaskResourceParameters, ModelState);
        }

        /// <summary>
        /// Get particullar task
        /// </summary>
        /// <param name="id">The id of the task you want to get</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "GetTask")]

        public ActionResult<TaskOutputDto> Get(Guid id)
        {
            var taskFromRepo = repository.GetSingleTask(id);

            if (taskFromRepo is null)
                return NotFound();

            var mappedTask = services.Map<TaskOutputDto>(taskFromRepo);

            return Ok(mappedTask);
        }

        /// <summary>
        /// Add a new task
        /// </summary>
        /// <param name="taskModel">The new task's model</param>
        /// <returns></returns>
        ///  /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(Name = "PostTask")]
        public ActionResult<TaskOutputDto> Post(TaskInputDto taskModel)
        {
            if (IsInvalid(taskModel))
                return ValidationProblem(ModelState);

            return AddNewTask(taskModel);
        }

        /// <summary>
        /// Update a task
        /// </summary>
        /// <param name="id">The id of the task you want to update</param>
        /// <param name="taskModel">The updated task's model</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}", Name = "UpdateTask")]
        public ActionResult<TaskOutputDto> Put(Guid id, TaskInputDto taskModel)
        {
            if (IsInvalid(taskModel))
                return ValidationProblem(ModelState);

            var taskFromRepo = repository.GetSingleTask(id);
            if (taskFromRepo is null)
                return AddNewTask(taskModel);

            services.Map(taskModel, taskFromRepo);
            repository.SaveChanges();

            return NoContent();
        }

        private ActionResult<TaskOutputDto> AddNewTask(TaskInputDto taskModel)
        {
            var newTask = services.Map<Task>(taskModel);

            repository.AddTask(newTask);
            repository.SaveChanges();

            var taskToReturn = services.Map<TaskOutputDto>(newTask);

            return CreatedAtRoute("GetTask", new { id = newTask.Id }, taskToReturn);
        }

        /// <summary>
        /// Partially update a task
        /// </summary>
        /// <param name="id">The id of the task you want to update</param>
        /// <param name="patchDocument">The set of operations to apply to the task</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request (this request mark the task as completed) \
        /// PATCH /tasks/id \
        /// [ \
        ///     { \
        ///         "op": "replace", \
        ///         "path": "/completed", \
        ///         "value": "true" \
        ///     } \
        ///]    
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{id}", Name = "PatchTask")]
        public IActionResult Patch(Guid id, JsonPatchDocument<TaskInputDto> patchDocument)
        {
            var taskFromRepo = repository.GetSingleTask(id);
            if (taskFromRepo is null)
                return NotFound();

            var taskModel = services.Map<TaskInputDto>(taskFromRepo);
            patchDocument.ApplyTo(taskModel, ModelState);

            if (IsInvalid(taskModel))
                return ValidationProblem(ModelState);

            services.Map(taskModel, taskFromRepo);
            repository.SaveChanges();

            return NoContent();
        }

        private bool IsInvalid(TaskInputDto task)
        {
            return services.IsInvalid(task as ITaskInputDto, ModelState);
        }

        /// <summary>
        /// Delete a task
        /// </summary>
        /// <param name="id">The id of the tash you want to delete</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}", Name = "DeleteTask")]
        public IActionResult Delete(Guid id)
        {
            var taskFromRepo = repository.GetSingleTask(id);

            if (taskFromRepo is null)
                return NotFound();

            repository.DeleteTask(taskFromRepo);
            repository.SaveChanges();

            return NoContent();
        }
    }
}