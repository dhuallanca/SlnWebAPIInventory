using Application.Dtos;
using Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    // reference: https://code-maze.com/mapster-aspnetcore-introduction/
    public static class MapsterConfiguration
    {
        public static void RegisterMapsterConfigure(this IServiceCollection services)
        {
            TypeAdapterConfig<Model, ModelDto>.NewConfig();

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
