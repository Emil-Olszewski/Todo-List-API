using Microsoft.Extensions.DependencyInjection;
using Todo.Infrastructure.FluentValidation;

namespace Todo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IValidationManager, ValidationManager>();

            return services;
        }
    }
}