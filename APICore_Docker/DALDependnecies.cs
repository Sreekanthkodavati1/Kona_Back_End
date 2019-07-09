using Core_DAL;
using Core_DALInterface;
using Microsoft.Extensions.DependencyInjection;

namespace Core_APIService
{
    public static class DALDependnecies
    {
        public static void RegisterDALDependnecies(IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IUserDAL), typeof(UserDAL), ServiceLifetime.Singleton));
        }
    }
}
