using FluentAssertions;
using System.IO;
using TestableConsoleApp.Infrastructure.FileStorage.Repositories;
using Xunit;

namespace TestableConsoleApp.Infrastructure.FileStorage.Tests.UnitTests
{
    public class LocalStorageRepositoryUnitTests
    {
        [Fact]
        public void CleansDirectoryBeforeRunning()
        {
            // Arrange
            var pathToSave = "C:\\Arquivos";

            // Act
            _ = new LocalStorageRepository(pathToSave);

            // Assert
            var directoryInfo = new DirectoryInfo(pathToSave);
            directoryInfo.Exists.Should().BeTrue();
            directoryInfo.EnumerateFiles().Should().BeEmpty();
        }
    }
}
