using System.Collections.Generic;
using Autofac;
using Commands.Products;
using Dispatchers;
using Dto;
using Handlers;
using Queries;
using Repositories;

namespace IoC
{
    public class ContainerModule : Module
    {
        public ContainerModule()
        {
        }   

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>();
            builder.RegisterType<CreateProductHandler>()
                .As<ICommandHandler<CreateProduct>>();
            builder.RegisterType<QueryDispatcher>()
                .As<IQueryDispatcher>();
            builder.RegisterType<GetProductsHandler>()
                .As<IQueryHandler<GetProducts, IEnumerable<ProductDto>>>();
            builder.RegisterType<ProductsRepository>()
                .As<IProductsRepository>();
        }
    }
}