using Microsoft.Extensions.Configuration;

namespace Student.Command.Infra.Setup
{
    public static class AppConfiguration
    {
        public static IConfiguration Build()
            => new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();
    }
}
