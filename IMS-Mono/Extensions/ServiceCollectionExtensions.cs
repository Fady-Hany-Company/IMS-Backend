using IMS.Application.Interfaces;
using IMS.Infrastructure.Data;
using IMS.Infrastructure.Repositories;
using IMS.Infrastructure.UnitOfWork;
using IMS_Mono.Middlewares;
using IMS.Application.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;


namespace IMS_Mono.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<RequestLoggingMiddleware>();
            services.AddSingleton<IDbContextFactory, DbContextFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(IMS.Application.Common.AssemblyReference.Assembly);
            });

            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });

            return services;
        }
    }
}
