
using System.Collections.Generic;
using System;
namespace Avensia.Storefront.Developertest
{
    // public class ProductDto
    public class ProductDto : IComparable<ProductDto>
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
        public List<Property> Properties { get; set; }

        public int CompareTo(ProductDto other)
        {
            return this.Price.CompareTo(other.Price);
        }

    }

    public class Property
    {


        public string KeyName { get; set; }
        public string Value { get; set; }


    }

    public class SorfbyPrice : IComparer<ProductDto>
        {

        public int Compare(ProductDto x, ProductDto y)
        {
            return x.Price.CompareTo(y.Price);
        }

        }


}