using Microservices.Demo.Report.API.Infrastructure.Agents.Policy.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Infrastructure.Agents.Policy
{
    public interface IPolicyAgent
    {
        Task<IEnumerable<PolicyQueryResult>> FindAllPolicy();
    }
}
