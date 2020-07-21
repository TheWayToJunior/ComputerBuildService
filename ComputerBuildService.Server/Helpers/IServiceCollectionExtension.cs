using ComputerBuildService.Server.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace ComputerBuildService.Server.Helpers
{
    public static class IServiceCollectionExtension
    {
        public static IDictionary<string, IServiceCollection> AddDbService<TPrimaryKey>
            (this IServiceCollection services, params IDbServiceOptions<IEntity<TPrimaryKey>, TPrimaryKey>[] dbServices)
        {
            var servicesCollection = new Dictionary<string, IServiceCollection>();

            foreach (var serveiceOptions in dbServices)
            {
                servicesCollection.Add(serveiceOptions.Key,
                    services.AddScoped(serveiceOptions.ServiceType, serveiceOptions.InplimentalType));
            }

            return servicesCollection;
        }

        public static void InitDbServices(this IServiceCollection services)
        {
            ConfigureDbServices.Configure(services);
        }
    }
}
