using Student.Command.Domain.Exceptions.Abstraction.Exceptions;

namespace Student.Command.Domain.Exceptions.Abstraction
{
    public class AppException(ExceptionStatusCode statusCode, string message) : Exception(message)
    {
        public ExceptionStatusCode StatusCode { get; set; } = statusCode;
    }
}
