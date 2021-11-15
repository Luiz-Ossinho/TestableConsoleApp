using System.Threading.Tasks;
using TestableConsoleApp.Shared.Models.Shared;

namespace TestableConsoleApp.Shared.Interfaces.Shared
{
    public interface ICommandHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
        Task<IResult<TResponse>> Handle(TCommand command);
    }
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task<IResult<Nothing>> Handle(TCommand command);
    }
}
