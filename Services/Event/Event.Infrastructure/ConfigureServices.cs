using Event.Infrastructure.Context;
using Event.Infrastructure.Repositories;
using Event.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace Event.Infrastructure;

 public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }