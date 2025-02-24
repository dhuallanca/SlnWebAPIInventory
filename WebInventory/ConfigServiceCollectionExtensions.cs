using Infrastructure.Interfaces;
using WebInventory.Utilities;

namespace WebInventory
{
    /// <summary>
    /// To separate the dependency injection from program file
    /// </summary>
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services) {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserIdProvider, UserIdProvider>();
            return services;
        }
    }
}
