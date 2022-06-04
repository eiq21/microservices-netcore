using Microservices.Demo.Report.API.Infrastructure.Agents.Product.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Infrastructure.Agents.Product
{
    public class ProductAgent : IProductAgent
    {
        private readonly IProductClient productClient;

        public ProductAgent(IProductClient productClient)
        {
            this.productClient = productClient;
        }
        public async Task<IEnumerable<ProductQueryResult>> FindAllProduct()
        {
            try
            {
                return await productClient.FindAllProducts(); 
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
