using System.Text.Json;
using Todo.Application.Services.Models;
using Todo.Domain;

namespace Todo.Application.Services.Implementations
{
    public class Pagination : IPagination
    {
        public Header CreateHeader<T>(PagedList<T> elements)
        {
            var metadata = CreateMetadata(elements);
            var serializedMetadata = JsonSerializer.Serialize(metadata);

            return new Header(Constants.Pagination_Header_Name, serializedMetadata);
        }

        private PaginationMetadata CreateMetadata<T>(PagedList<T> elements)
        {
            return new PaginationMetadata
            {
                TotalCount = elements.TotalCount,
                PageSize = elements.PageSize,
                CurrentPage = elements.CurrentPage,
                TotalPages = elements.TotalPages
            };
        }
    }
}