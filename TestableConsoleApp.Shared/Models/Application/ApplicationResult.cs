using System.Collections.Generic;
using TestableConsoleApp.Shared.Interfaces.Shared;
using TestableConsoleApp.Shared.Models.Shared;

namespace TestableConsoleApp.Shared.Models.Application
{

    public class ApplicationResult : BaseResult, IResult
    {
        bool IResult<Nothing>.Succeeded => Succeeded;
        Nothing IResult<Nothing>.Data => Nothing.Value;
        IEnumerable<string> IResult<Nothing>.Errors => Errors;

        public ApplicationResult WithSuccess(bool success = true)
        {
            this.Succeeded = success;
            return this;
        }

        public ApplicationResult WithError(string error)
        {
            Errors.Add(error);
            return WithSuccess(false);
        }
    }

    public class ApplicationResult<TData> : BaseResult, IResult<TData>
    {
        bool IResult<TData>.Succeeded => Succeeded;
        IEnumerable<string> IResult<TData>.Errors => Errors;

        private TData Data { get; set; }
        TData IResult<TData>.Data => Data;

        public ApplicationResult<TData> WithSuccess(bool success = true)
        {
            this.Succeeded = success;
            return this;
        }
        public ApplicationResult<TData> WithError(string error)
        {
            Errors.Add(error);
            return WithSuccess(false);
        }
    }

    public class BaseResult
    {
        public BaseResult()
        {
            Succeeded = true;
            Errors = new List<string>();
        }

        public ICollection<string> Errors { get; set; }
        public bool Succeeded { get; set; }
    }
}
