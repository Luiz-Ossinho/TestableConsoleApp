using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableConsoleApp.Shared.Interfaces.FileGeneration.Services
{
    public interface IFileGenerator
    {
        Task<Stream> GenerateFile();
    }
}
