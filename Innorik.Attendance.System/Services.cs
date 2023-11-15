using Innorik.Attendance.System.Infrastructure.Persistence;
using MediatR;
using Microsoft.Net.Http.Headers;
using System.Reflection;

namespace Innorik.Attendance.System.Api
{
    public static class Services
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
           
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }

        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            options.AddPolicy("Development", builder =>
            {
                builder.WithMethods("GET", "POST", "PUT", "DELETE", "PATCH")
                .WithHeaders(
                    HeaderNames.Accept,
                    HeaderNames.ContentType,
                    HeaderNames.Authorization)
                .AllowCredentials()
                .SetIsOriginAllowed(origin =>
                {
                    if (string.IsNullOrWhiteSpace(origin)) return false;
                    if (origin.ToLower().StartsWith("https://localhost")) return true;
                    if (origin.ToLower().StartsWith("http://localhost")) return true;
                    if (origin.ToLower().StartsWith("https://production.domain")) return false;
                    return false;
                });
            })
            );

            return services;
        }
    }
}
