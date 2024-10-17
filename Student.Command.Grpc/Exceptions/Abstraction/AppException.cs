using Student.Command.Grpc.Exceptions.Abstraction.Exceptions;

namespace Student.Command.Grpc.Exceptions.Abstraction
{
    public class AppException(ExceptionStatusCode statusCode, string message) : Exception(message)
    {
        public ExceptionStatusCode StatusCode { get; set; } = statusCode;
    }
}
