using MediatR;
using Microservices.Demo.Policy.API.CQRS.Queries.Infrastructure.Dtos.Policy;
using System.Collections.Generic;

namespace Microservices.Demo.Policy.API.CQRS.Queries.Policy.FindAllPolicies
{
    public class FindAllPoliciesQuery : IRequest<IEnumerable<PolicyDto>>
    {
    }
}
