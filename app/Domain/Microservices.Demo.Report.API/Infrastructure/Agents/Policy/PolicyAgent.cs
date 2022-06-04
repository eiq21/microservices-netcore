using Microservices.Demo.Report.API.Infrastructure.Agents.Policy.Queries;
using Microservices.Demo.Report.API.Infrastructure.Agents.Product;
using Microservices.Demo.Report.API.Infrastructure.Agents.Product.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Infrastructure.Agents.Policy
{
    public class PolicyAgent : IPolicyAgent
    {
        private readonly IPolicyClient policyClient;
        public PolicyAgent(IPolicyClient policyClient)
        {
            this.policyClient = policyClient;
        }
        public async Task<IEnumerable<PolicyQueryResult>> FindAllPolicy()
        {
            try
            {
                var policies = await policyClient.FindAllPolicies();
                var result = policies.Select(policy => new PolicyQueryResult
                {
                    Number = policy.Number,
                    ProductCode = policy.ProductCode,
                    AgainLogin = policy.AgainLogin
                });

                return result;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Error when invoking the policy service", ex);
            }
        }


    }
}
