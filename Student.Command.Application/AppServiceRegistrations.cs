using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Student.Command.Application
{
    public static class AppServiceRegistrations
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
