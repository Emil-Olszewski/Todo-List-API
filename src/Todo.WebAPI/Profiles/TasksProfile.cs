using AutoMapper;
using Todo.Domain.Entities;
using Todo.WebAPI.Models.DTOs;

namespace Todo.WebAPI.Profiles
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<Task, TaskOutputDto>();
            CreateMap<TaskInputDto, Task>();
            CreateMap<Task, TaskInputDto>();
        }
    }
}