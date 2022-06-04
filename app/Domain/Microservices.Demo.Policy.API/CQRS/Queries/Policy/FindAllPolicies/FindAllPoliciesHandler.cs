using MediatR;
using Microservices.Demo.Policy.API.CQRS.Queries.Infrastructure.Dtos.Policy;
using Microservices.Demo.Policy.API.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.CQRS.Queries.Policy.FindAllPolicies
{
    public class FindAllPoliciesHandler : IRequestHandler<FindAllPoliciesQuery, IEnumerable<PolicyDto>>
    {
        private readonly IPolicyRepository policyRepository;
        public FindAllPoliciesHandler(IPolicyRepository policyRepository)
        {
            this.policyRepository = policyRepository ?? throw new ArgumentNullException(nameof(policyRepository));
        }
        public async Task<IEnumerable<PolicyDto>> Handle(FindAllPoliciesQuery request, CancellationToken cancellationToken)
        {
            var result = await policyRepository.FindAll();

            return result.Select(policy => new PolicyDto {
              Number = policy.Number,
              ProductCode = policy.ProductCode,
              AgainLogin = policy.AgentLogin
            });
        }
    }
}
