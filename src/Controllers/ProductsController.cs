using System.Collections.Generic;
using System.Threading.Tasks;
using Commands.Products;
using Dispatchers;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Queries;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ProductsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery] GetProducts query)
        {
            var products = await _queryDispatcher.QueryAsync(query);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProduct command)
        {
            await _commandDispatcher.DispachAsync(command);
            return Accepted();
        }
    }
}
