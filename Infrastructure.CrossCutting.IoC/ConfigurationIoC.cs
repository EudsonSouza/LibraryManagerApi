
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Services;
using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Services;
using Infrastructure.Repository;
using Infrastructure.CrossCutting.Adapter.Interfaces;
using Infrastructure.CrossCutting.Adapter.Map;

namespace Infrastructure.CrossCutting.IoC
{
    public class ConfigurationIoC
    {
        public static void ConfigureDependencyInjection(IServiceCollection serviceCollection) {

            serviceCollection.AddScoped<IRepositoryAuthor, RepositoryAuthor>();
            serviceCollection.AddScoped<IApplicationServiceAuthor, ApplicationServiceAuthor>();
            serviceCollection.AddScoped<IServiceAuthor, ServiceAuthor>();


            serviceCollection.AddSingleton<IMapperAuthor, MapperAuthor>();


        }
    }
}
