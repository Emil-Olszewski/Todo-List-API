using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Services;
using Todo.Application.Services.Implementations;

namespace Todo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ICompletionCondition, CompletionCondition>();
            services.AddTransient<IPagination, Pagination>();
            services.AddTransient<IRepository, Repository>();

            return services;
        }
    }
}