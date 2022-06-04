using Microservices.Demo.Report.API.Infrastructure.Agents.Product.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Infrastructure.Agents.Product
{
    public interface IProductAgent
    {
        Task<IEnumerable<ProductQueryResult>> FindAllProduct();
    }
}
