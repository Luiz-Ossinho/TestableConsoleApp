using System.IO;
using System.Threading.Tasks;

namespace TestableConsoleApp.Shared.Interfaces.FileStorage.Repositories
{
    public interface IFileStorageRepository
    {
        Task SaveStreamAsFile(Stream streamFile);
    }
}
