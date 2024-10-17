using System.Text.Json.Serialization;

namespace Student.Command.Domain.Exceptions.Abstraction.Exceptions
{
    public class ServiceProblemDetails
    {
        public ServiceProblemDetails(string title, string type, string detail, string instance, IDictionary<string, object> extensions, ExceptionStatusCode statusCode)
        {
            Title = title;
            Type = type;
            Detail = detail;
            Instance = instance;
            Extensions = extensions;
            StatusCode = statusCode;
        }
        public ServiceProblemDetails(string title, ExceptionStatusCode statusCode)
        {
            Title = title;
            StatusCode = statusCode;
        }
        public string Title { get; init; }
        public string Type { get; init; } = string.Empty;
        public string Detail { get; init; } = string.Empty;
        public string Instance { get; init; } = string.Empty;
        public IDictionary<string, object> Extensions { get; init; } = new Dictionary<string, object>(StringComparer.Ordinal);

        [JsonIgnore]
        public ExceptionStatusCode StatusCode { get; init; }
    }
}
