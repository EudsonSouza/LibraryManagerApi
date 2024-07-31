using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using System.Linq;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remover o contexto do SqlContext registrado
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<SqlContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Adicionar o contexto do SqlContext usando InMemoryDatabase
            services.AddDbContext<SqlContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            // Criar o escopo para inicializar o banco de dados
            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<SqlContext>();
            db.Database.EnsureCreated();
        });
    }
}
