using Domain.Interfaces;
using Domain.Interfaces.Entrreprise;
using Domain.Interfaces.Identity;
using Infrastructure.Repository;
using Infrastructure.Repository.Entreprise;
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
            services.AddTransient<ISubsidiaryRepository, SubsidiaryRepository>();
            return services;
        }
    }
}
