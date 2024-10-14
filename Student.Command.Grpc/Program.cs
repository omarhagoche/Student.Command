using Calzolari.Grpc.AspNetCore.Validation;
using Microsoft.EntityFrameworkCore;
using Student.Command.Grpc.Data;
using Student.Command.Grpc.Data.Repositories;
using Student.Command.Grpc.Data.Repositories.Abstract;
using Student.Command.Grpc.Data.Services;
using Student.Command.Grpc.Data.Services.Abstract;
using Student.Command.Grpc.Services;
using Student.Command.Grpc.Validators.Main;
using System.Reflection;

namespace Student.Command.Grpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc(options =>
            {
                options.EnableMessageValidation();
            });

            builder.Services.AddDbContext<AppDbCon>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<ICommitEventsService, CommitEventsService>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddAppValidators();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<StudentCommandService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}