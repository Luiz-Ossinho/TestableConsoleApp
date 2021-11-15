using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableConsoleApp.Shared.Models.Shared;

namespace TestableConsoleApp.Shared.Interfaces.Shared
{
    public interface IResult<T>
    {
        public bool Succeeded { get; }
        public T Data { get; }
        public IEnumerable<string> Errors { get; }
    }

    public interface IResult : IResult<Nothing> { }
}
