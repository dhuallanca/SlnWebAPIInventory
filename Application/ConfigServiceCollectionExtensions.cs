using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInyectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient<IService, Service>();

            return services;
        }
    }
}
