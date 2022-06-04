using Microservices.Demo.Report.API.Infrastructure.Agents.Policy;
using Microservices.Demo.Report.API.Infrastructure.Agents.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Demo.Report.API.Infrastructure.Agents
{
    public static class Extensions
    {
        public static IServiceCollection AddRestClients(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IPolicyClient), typeof(PolicyClient));
            services.AddSingleton(typeof(IPolicyAgent), typeof(PolicyAgent));

            services.AddSingleton(typeof(IProductClient), typeof(ProductClient));
            services.AddSingleton(typeof(IProductAgent), typeof(ProductAgent));

            return services;
        }
    }
}
