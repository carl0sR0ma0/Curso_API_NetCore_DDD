using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddDbContext<MyContext>(options => options.UseNpgsql("Server=127.0.0.1;Port=5432;Pooling=false;Database=dbAPI;User Id=postgres;Password=pentabr0610;"));
        }
    }
}
