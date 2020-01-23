using StructureMap;

namespace Avensia.Storefront.Developertest
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<ProductListVisualizer>().Use<ProductListVisualizer>();

            // Exclude DefaultExampleProductRepository, uses the sample data
            //For<IProductRepository>().Use<DefaultExampleProductRepository>();
            
        }
    }
}