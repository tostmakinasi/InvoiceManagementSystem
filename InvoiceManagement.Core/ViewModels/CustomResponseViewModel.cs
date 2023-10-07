using System.Text.Json.Serialization;

namespace InvoiceManagement.Core.ViewModels
{
    public class CustomResponseViewModel<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponseViewModel<T> Success( T data)
        {
            return new CustomResponseViewModel<T> { Data = data, Errors = null };
        }

        public static CustomResponseViewModel<T> Success()
        {
            return new CustomResponseViewModel<T> { };
        }

        public static CustomResponseViewModel<T> Fail( string error)
        {
            return new CustomResponseViewModel<T> { Errors = new() { error } };
        }

        public static CustomResponseViewModel<T> Fail( List<string> errors)
        {
            return new CustomResponseViewModel<T> { Errors = errors };
        }
    }
}
