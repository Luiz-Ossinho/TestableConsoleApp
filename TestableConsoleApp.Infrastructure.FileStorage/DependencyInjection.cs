using Microsoft.Extensions.DependencyInjection;
using TestableConsoleApp.Infrastructure.FileStorage.Repositories;
using TestableConsoleApp.Shared.Interfaces.FileStorage.Repositories;

namespace TestableConsoleApp.Infrastructure.FileStorage
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFileStorage(this IServiceCollection services)
        {
            services.AddSingleton(sp => new LocalStorageRepository("C:\\Arquivos") as IFileStorageRepository);

            return services;
        }
    }
}
