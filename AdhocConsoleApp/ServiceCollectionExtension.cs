using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AdhocConsoleApp
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AutoRegisterServices(this IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            var assemblyTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => Tuple.Create(t, t.GetInterfaces()));

            foreach (var (implementationType, servicesTypes) in assemblyTypes)
            {
                foreach (var serviceType in servicesTypes)
                {
                    services.Add(new ServiceDescriptor(serviceType, implementationType, serviceLifetime));
                }
            }

            return services;
        }
    }
}
