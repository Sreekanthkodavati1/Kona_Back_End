using Core_BAL;
using Core_BALInterfaceCore;
using Core_DomainModel;
using Microsoft.Extensions.DependencyInjection;

namespace Core_APIService
{
    public static class BALDependnecies
    {
        public static void RegisterBALDependnecies(IServiceCollection services)
        {
            services.AddScoped<IEntityBAL<User>, UserBAL>();
            //services.Add(new ServiceDescriptor(typeof(IEntityBAL<UserBAL>), typeof(UserBAL), ServiceLifetime.Singleton));
        }
    }
}
