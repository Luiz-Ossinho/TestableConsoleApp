using TestableConsoleApp.Shared.Models.Shared;

namespace TestableConsoleApp.Shared.Interfaces.Shared
{

    // Interface de marcaçao para um comando que nao tem resposta alguma
    public interface ICommand : ICommand<Nothing> { }

    // Interface de marcaçao para um comando que tem resposta
    public interface ICommand<out TResponse> { }
}
