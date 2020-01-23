using System.Collections.Generic;

namespace Avensia.Storefront.Developertest
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetProducts();
        IEnumerable<ProductDto> GetProducts(int start, int pageSize);
    }
}