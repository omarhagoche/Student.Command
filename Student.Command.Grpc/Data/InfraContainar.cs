using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Student.Command.Grpc.Data.Repositories;
using Student.Command.Grpc.Data.Repositories.Abstract;
using Student.Command.Grpc.Data.Services;
using Student.Command.Grpc.Data.Services.Abstract;
using Student.Command.Grpc.Data.Services.ServiceBus;

namespace Student.Command.Grpc.Data
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
