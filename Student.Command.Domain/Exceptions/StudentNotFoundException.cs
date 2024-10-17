using Student.Command.Domain.Exceptions.Abstraction.Exceptions;
using Student.Command.Domain.Resourses;

namespace Student.Command.Domain.Exceptions
{
    public class StudentNotFoundException : Exception, IProblemDetailsProvider
    {
        public ServiceProblemDetails GetProblemDetails()
            => new(Phrases.StudentNotFound, ExceptionStatusCode.NotFound);
    }
}
