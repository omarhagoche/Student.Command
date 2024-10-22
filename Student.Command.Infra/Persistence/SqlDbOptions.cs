using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Student.Command.Infra.Persistence
{
    public class SqlDbOptions
    {
        public const string SqlDb = "ConnectionStrings";
        public const string SqlDbUnitTesting = "TestSettings:UnitTesting";
        public const string SqlDbLiveTesting = "TestSettings:LiveTesting";

        [Required]
        public required string Database { get; init; }

        public void SetUnitTestOptions(IConfiguration configuration)
        {
            configuration.GetSection(SqlDbUnitTesting).Bind(this);
        }

        public void SetLiveTestOptions(IConfiguration configuration)
        {
            configuration.GetSection(SqlDbLiveTesting).Bind(this);
        }
    }
}
