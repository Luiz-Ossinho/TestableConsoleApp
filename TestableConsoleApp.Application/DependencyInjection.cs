using Microsoft.Extensions.DependencyInjection;
using TestableConsoleApp.Application.UseCases;
using TestableConsoleApp.Shared.Interfaces.Shared;

namespace TestableConsoleApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ICommandHandler<Create10FilesCommand>, Create10FilesCommandHandler>();

            return services;
        }
    }
}
