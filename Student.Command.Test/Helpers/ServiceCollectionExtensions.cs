using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Student.Command.Application.Contracts.Services;
using Student.Command.Infra.Persistence;
using Student.Command.Test.Helpers.FakeServices;
[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace Student.Command.Test.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static void SetUnitTestsDefaultEnvironment(this IServiceCollection services)
        {
            UseSqlDatabaseTesting(services);

            RemoveServiceBusLogic(services);
        }

        private static void UseSqlDatabaseTesting(IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services.Configure<SqlDbOptions>(c => c.SetUnitTestOptions(configuration));

            var descriptor = services.Single(d => d.ServiceType == typeof(DbContextOptions<AppDbCon>));

            services.Remove(descriptor);

            services.AddDbContext<AppDbCon>((provider, configure) =>
            {
                var options = provider.GetRequiredService<IOptions<SqlDbOptions>>();

                configure.UseSqlServer(options.Value.Database);
            });

            services.AddHostedService<DbTruncate>();
        }

        private static void RemoveServiceBusLogic(IServiceCollection services)
        {
            var descriptor = services.Single(d => d.ServiceType == typeof(IServiceBusPublisher));
            services.Remove(descriptor);


            services.AddSingleton<IServiceBusPublisher, FakeServiceBusPublisher>();
        }
    }

    public class DbTruncate : IHostedService
    {
        private readonly IServiceProvider _provider;

        public DbTruncate(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbCon>();

            await context.Database.MigrateAsync();

            context.RemoveRange(context.OutboxMessages);
            context.RemoveRange(context.Events);
            await context.SaveChangesAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
