using Microsoft.AspNetCore.Mvc.ModelBinding;
using Todo.Application.Services.Models;

namespace Todo.WebAPI.Helpers
{
    public interface IControllerServices
    {
        Header CreateHeader<T>(PagedList<T> elements);

        bool IsInvalid<T>(T input, ModelStateDictionary modelState);

        T Map<T>(object source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}