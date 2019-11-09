using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Queries;

namespace Repositories
{
    public interface IProductsRepository
    {
        Task AddAsync(Product product);
        Task<IEnumerable<Product>> GetProducts(GetProducts query);
    }
}