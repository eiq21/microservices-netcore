using Microservices.Demo.Report.API.Infrastructure.Agents.Product.Queries;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Infrastructure.Agents.Product
{
    public interface IProductClient
    {
        [Get]
        Task<IEnumerable<ProductQueryResult>> FindAllProducts();
    }
}
