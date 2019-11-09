using System.Collections.Generic;
using Dto;

namespace Queries
{
    public class GetProducts : IQuery<IEnumerable<ProductDto>>
    {
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
}