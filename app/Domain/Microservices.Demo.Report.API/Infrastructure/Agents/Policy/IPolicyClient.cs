using Microservices.Demo.Report.API.Infrastructure.Agents.Policy.Queries;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Infrastructure.Agents.Policy
{
    public interface IPolicyClient
    {
        [Get]
        Task<IEnumerable<PolicyQueryResult>> FindAllPolicies();
    }
}
