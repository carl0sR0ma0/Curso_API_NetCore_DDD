using Domain.Interfaces.Services.County;
using Domain.Interfaces.Services.UF;
using Domain.Interfaces.Services.User;
using Domain.Interfaces.Services.ZipCode;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection servicesCollection)
        {
            servicesCollection.AddTransient<IUserService, UserService>();
            servicesCollection.AddTransient<ILoginService, LoginService>();

            servicesCollection.AddTransient<ICountyService, CountyService>();
            servicesCollection.AddTransient<IUFService, UFService>();
            servicesCollection.AddTransient<IZipCodeService, ZipCodeService>();
        }
    }
}
