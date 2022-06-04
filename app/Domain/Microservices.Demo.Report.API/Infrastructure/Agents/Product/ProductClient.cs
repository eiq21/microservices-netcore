using Microservices.Demo.Report.API.Infrastructure.Agents.Product.Queries;
using Microservices.Demo.Report.API.Infrastructure.Configuration;


using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Infrastructure.Agents.Product
{
    using Microsoft.Extensions.Options;
    using RestEase;
    using Polly;
    using Steeltoe.Common.Discovery;
    using Steeltoe.Discovery;
    public class ProductClient : IProductClient
    {
        private readonly ServicesUrl _servicesUrl;
        private readonly IProductClient productClient;

        private static IAsyncPolicy retryPolicy = Policy
          .Handle<HttpRequestException>()
          .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(3));

        public ProductClient(IOptions<ServicesUrl> servicesUrl, IDiscoveryClient discoveryClient)
        {
            _servicesUrl = servicesUrl.Value;
            var handler = new DiscoveryHttpClientHandler(discoveryClient);
            handler.ServerCertificateCustomValidationCallback = delegate { return true; };
            var httpClient = new HttpClient(handler, false)
            {
                //BaseAddress = new Uri(_servicesUrl.ProductApiUrl)
                BaseAddress = new Uri("http://Microservices.Demo.Product.API/api/products")
                
            };

            productClient = RestClient.For<IProductClient>(httpClient);
        }

        public Task<IEnumerable<ProductQueryResult>> FindAllProducts()
        {
            return retryPolicy.ExecuteAsync(async () => await productClient.FindAllProducts());
        }
    }
}
