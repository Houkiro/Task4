using BLL.Interfaces;
using BLL.Services;
using Core.Interfaces;
using DAL;
using DAL.Repository;
using LoggerService;
using Microsoft.EntityFrameworkCore;

namespace Task4.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddSqlServer<RepositoryContext>((configuration.GetConnectionString("sqlConnection")));

    }
}