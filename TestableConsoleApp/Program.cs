using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestableConsoleApp.Application.UseCases;
using TestableConsoleApp.Shared.Interfaces.Shared;

namespace TestableConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddConsoleApplication()
                .BuildServiceProvider();

            var command = new Create10FilesCommand();
            var handler = serviceProvider.GetRequiredService<ICommandHandler<Create10FilesCommand>>();

            var result = await handler.Handle(command);

            var strResult = result.Succeeded ? "um sucesso" : "uma falha";
            sbyte count = 0;
            var strErrors = result.Errors.Any() ? result.Errors.Aggregate(func: (result, error) =>
            {
                if (count == 0)
                    return $"{error}";

                return result += $"\n {error}";
            }) : "Nao houveram erros";

            Console.WriteLine($"A operaçao foi {strResult}!");
            Console.WriteLine(strErrors);
        }
    }
}
