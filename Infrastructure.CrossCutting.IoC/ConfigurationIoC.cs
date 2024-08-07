
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

            serviceCollection.AddScoped<IAuthorRepository, AuthorRepository>();
            serviceCollection.AddScoped<IAuthorApplicationService, AuthorApplicationService>();
            serviceCollection.AddScoped<IAuthorService, AuthorService>();
            serviceCollection.AddScoped<IAuthorMapper, AuthorMapper>();


            serviceCollection.AddScoped<IBookGenreRepository, BookGenreRepository>();
            serviceCollection.AddScoped<IBookGenreApplicationService, BookGenreApplicationService>();
            serviceCollection.AddScoped<IBookGenreService, BookGenreService>();
            serviceCollection.AddScoped<IBookGenreMapper, BookGenreMapper>();


            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IBookApplicationService, BookApplicationService>();
            serviceCollection.AddScoped<IBookService, BookService>();
            serviceCollection.AddScoped<IBookMapper, BookMapper>();


        }
    }
}
