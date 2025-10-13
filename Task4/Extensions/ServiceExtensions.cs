using BLL.Interfaces;
using BLL.Services;
using Core.Interfaces;
using DAL.InMemoryRepository;
using LoggerService;

namespace Task4.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddSingleton<IRepositoryManager, RepositoryManager>(); // синглтоновский чтобы не стирались данные при запросах пока нет бд
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
    }
}
