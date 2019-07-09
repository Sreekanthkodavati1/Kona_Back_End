using Core_BAL;
using Core_BALInterfaceCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core_APIService
{
    public static class BALDependnecies
    {
        public static void RegisterBALDependnecies(IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IUserBAL), typeof(UserBAL), ServiceLifetime.Singleton));
        }
    }
}
