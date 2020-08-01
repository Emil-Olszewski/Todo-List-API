using Todo.Application.Services;
using Todo.Application.Services.Models;
using Todo.WebAPI.Helpers;

namespace Todo.WebAPI.Controllers.Common
{
    public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected readonly IRepository repository;
        protected readonly IControllerServices services;

        public ControllerBase(IRepository repository, IControllerServices services)
        {
            this.repository = repository;
            this.services = services;
        }

        protected void AddPaginationHeader<T>(PagedList<T> elements)
        {
            var paginationHeader = services.CreateHeader(elements);
            Response.Headers.Add(paginationHeader.Name, paginationHeader.Value);
            AllowHeadersToUse(paginationHeader.Name);
        }

        protected void AllowHeadersToUse(params string[] headersNames)
        {
            var joinedHeaderNames = string.Join(", ", headersNames);
            Response.Headers.Add("Access-Control-Expose-Headers", joinedHeaderNames);
        }
    }
}