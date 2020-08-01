using Todo.Application.Services.Models;

namespace Todo.Application.Services
{
    public interface IPagination
    {
        Header CreateHeader<T>(PagedList<T> elements);
    }
}