using FluentAssertions;
using Moq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestableConsoleApp.Application.UseCases;
using TestableConsoleApp.Shared.Interfaces.FileGeneration.Services;
using TestableConsoleApp.Shared.Interfaces.FileStorage.Repositories;
using Xunit;

namespace TestableConsoleApp.Application.Tests.UnitTests
{
    public class Create10FilesCommandHandlerUnitTests
    {
        [Fact]
        public async Task ReturnsNoErrors()
        {

            // Arrange
            var mockFileStorage = new Mock<IFileStorageRepository>();
            var mockFileGenerator = new Mock<IFileGenerator>();

            mockFileStorage.Setup(fileStorage => fileStorage.SaveStreamAsFile(It.IsAny<Stream>()))
                .Returns(Task.CompletedTask);

            mockFileGenerator.Setup(fileGenerator => fileGenerator.GenerateFile())
                .ReturnsAsync(new MemoryStream());

            var handler = new Create10FilesCommandHandler(mockFileGenerator.Object, mockFileStorage.Object);
            var command = new Create10FilesCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public async Task ReturnsSuccess()
        {

            // Arrange
            var mockFileStorage = new Mock<IFileStorageRepository>();
            var mockFileGenerator = new Mock<IFileGenerator>();

            mockFileStorage.Setup(fileStorage => fileStorage.SaveStreamAsFile(It.IsAny<Stream>()))
                .Returns(Task.CompletedTask);

            mockFileGenerator.Setup(fileGenerator => fileGenerator.GenerateFile())
                .ReturnsAsync(new MemoryStream());

            var handler = new Create10FilesCommandHandler(mockFileGenerator.Object, mockFileStorage.Object);
            var command = new Create10FilesCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            result.Succeeded.Should().BeTrue();
        }

        [Fact]
        public async Task Creates10Files()
        {

            // Arrange
            var mockFileStorage = new Mock<IFileStorageRepository>();
            var mockFileGenerator = new Mock<IFileGenerator>();

            mockFileStorage.Setup(fileStorage => fileStorage.SaveStreamAsFile(It.IsAny<Stream>()))
                .Returns(Task.CompletedTask);

            mockFileGenerator.Setup(fileGenerator => fileGenerator.GenerateFile())
                .ReturnsAsync(new MemoryStream());

            var handler = new Create10FilesCommandHandler(mockFileGenerator.Object, mockFileStorage.Object);
            var command = new Create10FilesCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            mockFileGenerator.Verify(mock => mock.GenerateFile(), Times.Exactly(10));
            mockFileStorage.Verify(mock => mock.SaveStreamAsFile(It.IsAny<Stream>()), Times.Exactly(10));
        }

        [Fact]
        public async Task DoesntStoreFiles_When_NoneCouldBeGenerated()
        {

            // Arrange
            var mockFileStorage = new Mock<IFileStorageRepository>();
            var mockFileGenerator = new Mock<IFileGenerator>();

            mockFileGenerator.Setup(fileGenerator => fileGenerator.GenerateFile())
                .ReturnsAsync(()=>null);

            mockFileStorage.Setup(fileStorage => fileStorage.SaveStreamAsFile(It.IsAny<Stream>()))
                .Returns(Task.CompletedTask);

            var handler = new Create10FilesCommandHandler(mockFileGenerator.Object, mockFileStorage.Object);
            var command = new Create10FilesCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            mockFileStorage.Verify(mock => mock.SaveStreamAsFile(It.IsAny<Stream>()), Times.Never());
        }

        [Fact]
        public async Task Fails_When_NoFilesCouldBeGenerated()
        {
            // Arrange
            var mockFileStorage = new Mock<IFileStorageRepository>();
            var mockFileGenerator = new Mock<IFileGenerator>();

            mockFileGenerator.Setup(fileGenerator => fileGenerator.GenerateFile())
                .ReturnsAsync(() => null);

            mockFileStorage.Setup(fileStorage => fileStorage.SaveStreamAsFile(It.IsAny<Stream>()))
                .Returns(Task.CompletedTask);

            var handler = new Create10FilesCommandHandler(mockFileGenerator.Object, mockFileStorage.Object);
            var command = new Create10FilesCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            result.Succeeded.Should().BeFalse();
        }

        [Fact]
        public async Task FailsWithASpecificError_When_NoFilesCouldBeGenerated()
        {
            // Arrange
            var mockFileStorage = new Mock<IFileStorageRepository>();
            var mockFileGenerator = new Mock<IFileGenerator>();

            mockFileGenerator.Setup(fileGenerator => fileGenerator.GenerateFile())
                .ReturnsAsync(() => null);

            mockFileStorage.Setup(fileStorage => fileStorage.SaveStreamAsFile(It.IsAny<Stream>()))
                .Returns(Task.CompletedTask);

            var handler = new Create10FilesCommandHandler(mockFileGenerator.Object, mockFileStorage.Object);
            var command = new Create10FilesCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            result.Errors.Should().NotBeEmpty();
            result.Errors.FirstOrDefault().Should().Be("Nao consegui gerar os arquivos");
        }

        [Fact]
        public async Task Fails_When_NoFilesCouldBeSaved()
        {
            // Arrange
            var mockFileStorage = new Mock<IFileStorageRepository>();
            var mockFileGenerator = new Mock<IFileGenerator>();

            mockFileGenerator.Setup(fileGenerator => fileGenerator.GenerateFile())
                .ReturnsAsync(new MemoryStream());

            mockFileStorage.Setup(fileStorage => fileStorage.SaveStreamAsFile(It.IsAny<Stream>()))
                .Throws(new Exception());

            var handler = new Create10FilesCommandHandler(mockFileGenerator.Object, mockFileStorage.Object);
            var command = new Create10FilesCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            result.Succeeded.Should().BeFalse();
        }

        [Fact]
        public async Task FailsWithASpecificError_When_NoFilesCouldBeSaved()
        {
            // Arrange
            var mockFileStorage = new Mock<IFileStorageRepository>();
            var mockFileGenerator = new Mock<IFileGenerator>();

            mockFileGenerator.Setup(fileGenerator => fileGenerator.GenerateFile())
                .ReturnsAsync(new MemoryStream());

            mockFileStorage.Setup(fileStorage => fileStorage.SaveStreamAsFile(It.IsAny<Stream>()))
                .Throws(new Exception());

            var handler = new Create10FilesCommandHandler(mockFileGenerator.Object, mockFileStorage.Object);
            var command = new Create10FilesCommand();

            // Act
            var result = await handler.Handle(command);

            // Assert
            result.Errors.Should().NotBeEmpty();
            result.Errors.FirstOrDefault().Should().Be("Nao consegui salvar os arquivos");
        }
    }
}
