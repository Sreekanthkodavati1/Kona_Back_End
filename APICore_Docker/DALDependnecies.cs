using Core_DAL;
using Core_DALInterface;
using Core_DomainModel;
using Microsoft.Extensions.DependencyInjection;

namespace Core_APIService
{
    public static class DALDependnecies
    {
        public static void RegisterDALDependnecies(IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, PostgresSqlRepository<User>>();
            //services.Add(new ServiceDescriptor(typeof(IUserDAL), typeof(UserDAL), ServiceLifetime.Singleton));
        }
    }
}
