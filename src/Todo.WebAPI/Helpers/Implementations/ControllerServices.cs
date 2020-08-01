using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Todo.Application.Services;
using Todo.Application.Services.Models;
using Todo.Infrastructure.FluentValidation;

namespace Todo.WebAPI.Helpers.Implementations
{
    public class ControllerServices : IControllerServices
    {
        private readonly IMapper mapper;
        private readonly IValidationManager validationManager;
        private readonly IPagination pagination;

        public ControllerServices(IMapper mapper,
            IValidationManager validationManager, IPagination pagination)
        {
            this.mapper = mapper;
            this.validationManager = validationManager;
            this.pagination = pagination;
        }

        public bool IsInvalid<T>(T input, ModelStateDictionary modelState)
        {
            return validationManager.IsInvalid(input, modelState);
        }

        public Header CreateHeader<T>(PagedList<T> elements)
        {
            return pagination.CreateHeader(elements);
        }

        public T Map<T>(object source)
        {
            return mapper.Map<T>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return mapper.Map(source, destination);
        }
    }
}