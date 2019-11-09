using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using Queries;
using System.Collections.Generic;

namespace Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Product> _products 
            => _database.GetCollection<Product>("products");

        public ProductsRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Product product)
            => await _products.InsertOneAsync(product);

        public async Task<IEnumerable<Product>> GetProducts(GetProducts query)
        {
            var from = Builders<Product>.Filter.Gte("price", 
                query.PriceFrom == null 
                ? 0 
                : query.PriceFrom);

            var to = Builders<Product>.Filter.Lte("price", 
                query.PriceTo == null 
                ? decimal.MaxValue 
                : query.PriceTo);
            
            return await _products.Find(from & to).ToListAsync();
        }
    }
}