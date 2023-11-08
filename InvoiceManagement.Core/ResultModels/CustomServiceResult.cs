using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.ResultModels
{
    public class CustomServiceResult<T>
    {
        public List<string> Errors { get; set; }
        public T Data { get; set; }
        public bool Succeeded { get; set; }

        public static CustomServiceResult<T> Success() => new() { Succeeded = true};
        public static CustomServiceResult<T> Success(T data) => new() { Data = data, Succeeded = true };

        public static CustomServiceResult<T> Fail(string errors) => new() { Errors = new List<string> { errors }, Succeeded = false };
        public static CustomServiceResult<T> Fail(List<string> errors) => new() { Errors = errors, Succeeded = false };
    }
}
