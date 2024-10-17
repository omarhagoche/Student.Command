using Grpc.Core;
using Grpc.Core.Interceptors;
using Student.Command.Grpc.Exceptions.Abstraction;
using Student.Command.Grpc.Exceptions.Abstraction.Exceptions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Student.Command.Grpc.Interceptors.ExceptionHandler
{
    public class ApplicationExceptionInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception e) when (e is IProblemDetailsProvider provider)
            {
                throw HandleProblemDetailsException(provider);
            }
            catch (Exception e) when (e is AppException appException)
            {
                throw new RpcException(new Status((StatusCode)appException.StatusCode, appException.Message));
            }
        }

        private static RpcException HandleProblemDetailsException(IProblemDetailsProvider provider)
        {
            var problemDetails = provider.GetProblemDetails();

            return new RpcException(new Status((StatusCode)problemDetails.StatusCode, problemDetails.Title),
             new Metadata
                {
                    new Metadata.Entry("problem-details-bin", GetProblemDetailsBytes(problemDetails))
                });
        }

        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        public static byte[] GetProblemDetailsBytes(ServiceProblemDetails problemDetails)
        {
            var json = JsonSerializer.Serialize(problemDetails, SerializerOptions);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
