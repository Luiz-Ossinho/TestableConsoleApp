using System.IO;
using System.Text;
using System.Threading.Tasks;
using TestableConsoleApp.Shared.Interfaces.FileGeneration.Services;

namespace TestableConsoleApp.Infrastructure.FileGeneration.Services
{
    public class GenericTextFileGenerator : IFileGenerator
    {
        public async Task<Stream> GenerateFile()
        {
            var message = @"Ola, mundo!
                            Eu sou um arquivo de texto";

            return new MemoryStream(Encoding.Default.GetBytes(message));
        }
    }
}
