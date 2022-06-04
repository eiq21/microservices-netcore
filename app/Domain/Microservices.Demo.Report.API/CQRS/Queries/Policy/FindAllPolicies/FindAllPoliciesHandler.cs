using MediatR;
using Microservices.Demo.Report.API.CQRS.Queries.Infrastructure.Dtos;
using Microservices.Demo.Report.API.Infrastructure.Agents.Policy;
using Microservices.Demo.Report.API.Infrastructure.Agents.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.CQRS.Queries.Policy.FindAllPolicies
{
    public class FindAllPoliciesHandler : IRequestHandler<FindAllPoliciesQuery, IEnumerable<PolicyDto>>
    {
        private readonly IPolicyAgent policyAgent;
        private readonly IProductAgent productAgent;

        public FindAllPoliciesHandler(IPolicyAgent policyAgent, IProductAgent productAgent)
        {
            this.policyAgent = policyAgent;
            this.productAgent = productAgent;
        }

        public async Task<IEnumerable<PolicyDto>> Handle(FindAllPoliciesQuery request, CancellationToken cancellationToken)
        {
            var products = await productAgent.FindAllProduct();
            if (products == null || !products.Any())
                throw new NotImplementedException("Error when invoking the product service");

            var policies = await policyAgent.FindAllPolicy();

            if (policies == null || !policies.Any())
                throw new NotImplementedException("Error when invoking the policy service");

            var result = policies.Select(policy => new PolicyDto()
            {
                AgainLogin = policy.AgainLogin,
                Number = policy.Number,
                ProductName = products
                              .Where(product => product.Code == policy.ProductCode)
                              .Select(a => a.Description).First(),
                ProductCode = policy.ProductCode
            });

            return result;
        }


    }
}
