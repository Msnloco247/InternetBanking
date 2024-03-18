using InternetBanking.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InternetBanking.Core.Application.Interfaces.Repositories;
using InternetBanking.Core.Application.Interfaces.Services;
using System.Reflection;

namespace InternetBanking.Core.Application
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));

            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
