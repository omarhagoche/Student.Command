using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.Command.Application.Contracts.Repositories;
using Student.Command.Application.Contracts.Services;
using Student.Command.Infra.Persistence;
using Student.Command.Infra.Persistence.Repositories;
using Student.Command.Infra.Services;
using Student.Command.Infra.Services.ServiceBus;

namespace Student.Command.Infra
{
    public static class InfraContainar
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbCon>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Database"));
            });

            services.AddSingleton(s =>
            {
                return new ServiceBusClient(configuration.GetConnectionString("ServiceBus"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICommitEventsService, CommitEventsService>();

            services.AddSingleton<IServiceBusPublisher, ServiceBusPublisher>();

            return services;
        }
    }
}
