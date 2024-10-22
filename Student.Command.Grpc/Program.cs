using Calzolari.Grpc.AspNetCore.Validation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Student.Command.Application;
using Student.Command.Grpc.Interceptors;
using Student.Command.Grpc.Interceptors.ExceptionHandler;
using Student.Command.Grpc.Services;
using Student.Command.Grpc.Validators.Main;
using Student.Command.Infra;
using Student.Command.Infra.Persistence;
using Student.Command.Infra.Services.Logger;
using System.Reflection;

namespace Student.Command.Grpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = LoggerServiceBuilder.Build();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc(options =>
            {
                options.Interceptors.Add<ThreadCultureInterceptor>();

                options.EnableMessageValidation();

                options.Interceptors.Add<ApplicationExceptionInterceptor>();
            });

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddAppServices();

            builder.Services.AddInfraServices(builder.Configuration);

            builder.Services.AddAppValidators();

            builder.Host.UseSerilog();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbCon>();
                context.Database.Migrate();
            }
            // Configure the HTTP request pipeline.
            app.MapGrpcService<StudentCommandService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}