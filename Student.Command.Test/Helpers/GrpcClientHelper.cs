using Microsoft.AspNetCore.Mvc.Testing;
using Student.Command.Grpc;
using Student.Command.Test.Protos;

namespace Student.Command.Test.Helpers
{
    public class GrpcClientHelper(WebApplicationFactory<Program> factory)
    {
        private readonly WebApplicationFactory<Program> _factory = factory;
        public TResult Send<TResult>(Func<StudentCommand.StudentCommandClient, TResult> send)
        {
            var client = new StudentCommand.StudentCommandClient(_factory.CreateGrpcChannel());
            return send(client);
        }

    }
}
