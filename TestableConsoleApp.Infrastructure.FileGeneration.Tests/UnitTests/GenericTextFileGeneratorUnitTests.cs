
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableConsoleApp.Infrastructure.FileGeneration.Services;
using Xunit;

namespace TestableConsoleApp.Infrastructure.FileGeneration.Tests.UnitTests
{
    public class GenericTextFileGeneratorUnitTests
    {
        [Fact]
        public async Task GeneratesSpecificMessage()
        {
            // Arrange
            var fileGenerator = new GenericTextFileGenerator();

            // Act
            var stream = await fileGenerator.GenerateFile();

            // Assert
            using var sreamReader = new StreamReader(stream, Encoding.UTF8);
            sreamReader.ReadToEnd().Should().Be(@"Ola, mundo!
                            Eu sou um arquivo de texto");
        }
        [Fact]
        public async Task GeneratesTheSameMessage()
        {
            // Arrange
            var fileGenerator = new GenericTextFileGenerator();

            // Act
            var firstStream = await fileGenerator.GenerateFile() as MemoryStream;
            var secondStream = await fileGenerator.GenerateFile() as MemoryStream;

            // Assert
            using var streamReader1 = new StreamReader(firstStream, Encoding.UTF8);
            using var streamReader2 = new StreamReader(secondStream, Encoding.UTF8);
            streamReader1.ReadToEnd().Should().Be(streamReader2.ReadToEnd());
        }
    }
}
