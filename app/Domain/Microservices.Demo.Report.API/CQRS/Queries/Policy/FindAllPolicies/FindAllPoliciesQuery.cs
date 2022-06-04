using MediatR;
using Microservices.Demo.Report.API.CQRS.Queries.Infrastructure.Dtos;
using System.Collections.Generic;

namespace Microservices.Demo.Report.API.CQRS.Queries.Policy.FindAllPolicies
{
    public class FindAllPoliciesQuery : IRequest<IEnumerable<PolicyDto>>
    {
    }
}
