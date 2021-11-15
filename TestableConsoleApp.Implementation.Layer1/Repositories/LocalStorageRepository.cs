using System;
using System.IO;
using System.Threading.Tasks;
using TestableConsoleApp.Shared.Interfaces.FileStorage.Repositories;

namespace TestableConsoleApp.Implementation.Layer1.Repositories
{
    public class LocalStorageRepository : IFileStorageRepository
    {
        private int FileSavedCounter = 0;
        private readonly string PathToSave = "C:\\Arquivos";
        public async Task SaveStreamAsFile(Stream streamFile)
        {
            var directory = new DirectoryInfo(PathToSave);

            if (!directory.Exists)
                directory.Create();

            var path = Path.Combine(PathToSave, GetFilename());

            using var outputFileStream = new FileStream(path, FileMode.Create);
            await streamFile.CopyToAsync(outputFileStream);
        }

        private string GetFilename() => $"File {FileSavedCounter++} {Guid.NewGuid()}.txt";
    }
}
