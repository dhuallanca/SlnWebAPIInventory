using Domain.Interfaces;
using Domain.Interfaces.Identity;
using Infrastructure.Repository;
using Infrastructure.Repository.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyInjectionInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IModelRepository, ModelRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
