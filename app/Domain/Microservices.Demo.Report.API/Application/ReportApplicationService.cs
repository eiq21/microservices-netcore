using MediatR;
using Microservices.Demo.Report.API.CQRS.Queries.Infrastructure.Dtos;
using Microservices.Demo.Report.API.CQRS.Queries.Policy.FindAllPolicies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Application
{
    public class ReportApplicationService
    {
        private readonly IMediator mediator;

        public ReportApplicationService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IEnumerable<PolicyDto>> GetAllPoliciesAsync()
        {
            return await mediator.Send(new FindAllPoliciesQuery());
        }
    }
}
