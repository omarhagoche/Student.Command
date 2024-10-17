using Student.Command.Grpc.Exceptions.Abstraction.Exceptions;
using Student.Command.Grpc.Resourses;

namespace Student.Command.Grpc.Exceptions
{
    public class StudentNotFoundException : Exception, IProblemDetailsProvider
    {
        public ServiceProblemDetails GetProblemDetails()
            => new(Phrases.StudentNotFound, ExceptionStatusCode.NotFound);
    }
}
