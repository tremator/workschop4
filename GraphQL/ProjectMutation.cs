using System.Collections.Generic;
using GraphQL.Types;
using WorkShop4.GraphQL.Types;
using WorkShop4.Models;
using WorkShop4.Repositories;

namespace WorkShop4.GraphQL
{
    public class ProjectMutation:ObjectGraphType
    {
        public ProjectMutation(ClientRepository clientRepository, ProductRepository productRepository, OrderRepository orderRepository){
            Field<OrderType>("createOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OrderInputType>>{Name = "input"}),
                resolve: context => orderRepository.Create(context.GetArgument<Order>("input"))
            );
            Field<ClientType>("createClient",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ClientInputType>>{Name = "input"}),
                resolve: context => clientRepository.Create(context.GetArgument<Client>("input"))
            );
            Field<ProductType>("createProduct",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductInputType>>{Name = "input"}),
                resolve: context => productRepository.Create(context.GetArgument<Product>("input"))
            );
        }
    }
}