using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commands;
using Dto;
using Queries;
using Repositories;

namespace Handlers
{
    public class GetProductsHandler : IQueryHandler<GetProducts, IEnumerable<ProductDto>>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductsHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        
        public async Task<IEnumerable<ProductDto>> HandleAsync(GetProducts query)
        {
            var products = await _productsRepository.GetProducts(query);
            return products.Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            }).ToList();
        }
    }
}