using System.Collections.Generic;

namespace Avensia.Storefront.Developertest
{
    public class DefaultExampleProductRepository : IProductRepository
    {
        public IEnumerable<ProductDto> GetProducts()
        {
            // return new List<IProductDto> { new DefaultProductDto { Id = "1", Name = "Example product", Price = 73 } };
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductDto> GetProducts(int start, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }
}