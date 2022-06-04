using Microservices.Demo.Report.API.Infrastructure.Agents.Policy.Queries;
using Microservices.Demo.Report.API.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Infrastructure.Agents.Policy
{
    using Polly;
    using RestEase;
    using Steeltoe.Common.Discovery;
    using Steeltoe.Discovery;
    public class PolicyClient : IPolicyClient
    {
        private readonly ServicesUrl _servicesUrl;
        private readonly IPolicyClient policyClient;

        private static IAsyncPolicy retryPolicy = Policy
           .Handle<HttpRequestException>()
           .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(3));


        public PolicyClient(IOptions<ServicesUrl> servicesUrl, IDiscoveryClient discoveryClient)
        {
            _servicesUrl = servicesUrl.Value;
            var handler = new DiscoveryHttpClientHandler(discoveryClient);
            handler.ServerCertificateCustomValidationCallback = delegate { return true; };
            var httpClient = new HttpClient(handler, false)
            {
                //BaseAddress = new Uri(_servicesUrl.PolicyApiUrl)
                BaseAddress = new Uri("http://Microservices.Demo.Policy.API/api/policies")
            };

            policyClient = RestClient.For<IPolicyClient>(httpClient);
        }
        public Task<IEnumerable<PolicyQueryResult>> FindAllPolicies()
        {
            return retryPolicy.ExecuteAsync(async () => await policyClient.FindAllPolicies());
        }
    }
}
