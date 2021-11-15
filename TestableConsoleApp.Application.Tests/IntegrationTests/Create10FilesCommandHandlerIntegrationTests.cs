using FluentAssertions;
using System.IO;
using System.Linq;
using TestableConsoleApp.Application.UseCases;
using TestableConsoleApp.Infrastructure.FileGeneration.Services;
using TestableConsoleApp.Infrastructure.FileStorage.Repositories;
using TestableConsoleApp.Shared.Interfaces.FileGeneration.Services;
using TestableConsoleApp.Shared.Interfaces.FileStorage.Repositories;
using Xunit;

namespace TestableConsoleApp.Application.Tests.IntegrationTests
{
    public class Create10FilesCommandHandlerIntegrationTests
    {
        [Fact]
        public void LeavesOnly10FilesInThePathToSave()
        {
            // Arrange
            const string _pathToSave = "C:\\Arquivos";
            IFileStorageRepository fileStorageRepo = new LocalStorageRepository(_pathToSave);
            IFileGenerator fileGeneratorService = new GenericTextFileGenerator();
            var handler = new Create10FilesCommandHandler(fileGeneratorService, fileStorageRepo);
            var command = new Create10FilesCommand();

            // Act
            var result = handler.Handle(command);

            // Assert
            var directoryInfo = new DirectoryInfo(_pathToSave);
            directoryInfo.EnumerateFiles().Should().HaveCount(10);
        }

        [Fact]
        public void FilesHaveSpecificMessage()
        {
            // Arrange
            const string _pathToSave = "C:\\Arquivos";
            IFileStorageRepository fileStorageRepo = new LocalStorageRepository(_pathToSave);
            IFileGenerator fileGeneratorService = new GenericTextFileGenerator();
            var handler = new Create10FilesCommandHandler(fileGeneratorService, fileStorageRepo);
            var command = new Create10FilesCommand();

            // Act
            var result = handler.Handle(command);

            // Assert
            var directoryInfo = new DirectoryInfo(_pathToSave);

            directoryInfo.EnumerateFiles().All(fileInfo =>
            {
                var fileText = File.ReadAllText(fileInfo.FullName);

                return fileText == @"Ola, mundo!
                            Eu sou um arquivo de texto";
            }).Should().BeTrue();
        }
    }
}
