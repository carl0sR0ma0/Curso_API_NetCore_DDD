using Data.Context;
using Data.Implementations;
using Data.Repository;
using Domain.Interfaces;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), ".."))
                .AddJsonFile("API.Environment/DbSettings.json", optional: false, reloadOnChange: true);
            
            var configurationJson = configurationBuilder.Build();
            var teste = configurationJson.GetSection("DB_CONNECTION_PG").Value;

            if (configurationJson.GetSection("DATABASE").Value.ToLower().Equals("Postgres".ToLower()))
                serviceCollection.AddDbContext<MyContext>(options => 
                                                          options.UseNpgsql(configurationJson.GetSection("DB_CONNECTION_PG").Value));
            else 
                serviceCollection.AddDbContext<MyContext>(options => options.UseSqlServer(configurationJson.GetSection("DB_CONNECTION_SS").Value));
        }
    }
}
