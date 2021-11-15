using Microsoft.Extensions.DependencyInjection;
using TestableConsoleApp.Application;
using TestableConsoleApp.Infrastructure.FileGeneration;
using TestableConsoleApp.Infrastructure.FileStorage;

namespace TestableConsoleApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConsoleApplication(this IServiceCollection services) {
            services.AddApplication();
            services.AddFileGeneration();
            services.AddFileStorage();

            return services;
        }
    }
}
