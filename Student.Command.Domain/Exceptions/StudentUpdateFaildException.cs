using Student.Command.Domain.Exceptions.Abstraction.Exceptions;
using Student.Command.Domain.Resourses;

namespace Student.Command.Domain.Exceptions
{
    public class StudentUpdateFaildException : Exception, IProblemDetailsProvider
    {
        public ServiceProblemDetails GetProblemDetails()
        => new ServiceProblemDetails(
            Phrases.UpdateStudentFaild,
            ExceptionStatusCode.FailedPrecondition);
    }
}
