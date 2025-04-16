namespace Hope.Application.Common.Models
{
    public class Result<T>
    {
        public bool Succeeded { get; private set; }
        public T Data { get; private set; }
        public string? Message { get; private set; }
        public Dictionary<string, string[]>? Errors { get; private set; }

        private Result(bool succeeded, T data, string? message, Dictionary<string, string[]>? errors)
        {
            Succeeded = succeeded;
            Data = data;
            Message = message;
            Errors = errors;
        }

        public static Result<T> Success(T data, string? message = null)
        {
            return new Result<T>(true, data, message, null);
        }

        public static Result<T> Failure(string message, Dictionary<string, string[]>? errors = null)
        {
            return new Result<T>(false, default, message, errors);
        }
    }

    public class Result
    {
        public bool Succeeded { get; private set; }
        public string Message { get; private set; }
        public Dictionary<string, string[]> Errors { get; private set; }

        private Result(bool succeeded, string message, Dictionary<string, string[]> errors)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = errors;
        }

        public static Result Success(string message = null)
        {
            return new Result(true, message, null);
        }

        public static Result Failure(string message, Dictionary<string, string[]> errors = null)
        {
            return new Result(false, message, errors);
        }
    }
}