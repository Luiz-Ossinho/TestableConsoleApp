using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestableConsoleApp.Shared.Interfaces.FileStorage.Repositories;

namespace TestableConsoleApp.Infrastructure.FileStorage.Repositories
{
    public class LocalStorageRepository : IFileStorageRepository
    {
        public LocalStorageRepository(string pathToSave)
        {
            _pathToSave = pathToSave;

            EnsureDirectoryClean(_pathToSave);
        }

        private readonly string _pathToSave;
        public async Task SaveStreamAsFile(Stream streamFile)
        {
            var path = Path.Combine(_pathToSave, GetFilename());

            using var outputFileStream = new FileStream(path, FileMode.Create);
            await streamFile.CopyToAsync(outputFileStream);
        }

        private int FileSavedCounter = 0;
        private string GetFilename() => $"File {FileSavedCounter++} {Guid.NewGuid()}.txt";
        private void EnsureDirectoryClean(string path)
        {
            var directory = new DirectoryInfo(_pathToSave);
            if (!directory.Exists)
                directory.Create();
            else if (directory.EnumerateFiles().Any())
                foreach (var file in directory.EnumerateFiles())
                    file.Delete();
        }
    }
}
