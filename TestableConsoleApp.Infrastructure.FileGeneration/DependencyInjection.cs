using Microsoft.Extensions.DependencyInjection;
using TestableConsoleApp.Infrastructure.FileGeneration.Services;
using TestableConsoleApp.Shared.Interfaces.FileGeneration.Services;

namespace TestableConsoleApp.Infrastructure.FileGeneration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFileGeneration(this IServiceCollection services)
        {
            services.AddSingleton<IFileGenerator, GenericTextFileGenerator>();

            return services;
        }
    }
}
