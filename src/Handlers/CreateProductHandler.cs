using System;
using System.Threading.Tasks;
using Commands.Products;
using Domain;
using Repositories;

namespace Handlers
{
    public class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IProductsRepository _productsRepository;

        public CreateProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        
        public async Task HandleAsync(CreateProduct command)
        {
            var id = command.Id == Guid.Empty ? Guid.NewGuid() : command.Id;
            var product = new Product(id, command.Name, command.Price, command.Description);
            await _productsRepository.AddAsync(product);
        }
    }
}