namespace Student.Command.Grpc.Exceptions.Abstraction.Exceptions
{
    public interface IProblemDetailsProvider
    {
        ServiceProblemDetails GetProblemDetails();
    }
}
