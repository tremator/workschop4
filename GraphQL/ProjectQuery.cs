using GraphQL.Types;
using WorkShop4.GraphQL.Types;
using WorkShop4.Repositories;

namespace WorkShop4.GraphQL
{
    public class ProjectQuery:ObjectGraphType
    {
        public ProjectQuery(ClientRepository clientRepository, ProductRepository productRepository, OrderRepository orderRepository){
            Field<ListGraphType<ProductType>>("products",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>{ Name = "id"},
                    new QueryArgument<StringGraphType>{ Name = "name"},
                    new QueryArgument<FloatGraphType>{ Name = "price"},
                    new QueryArgument<IntGraphType>{ Name = "quantity"}
                ),
                resolve: context => productRepository.Filter(context)
            );
            Field<ListGraphType<ClientType>>("clients",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>{ Name = "id"}
                ),
                resolve: context => clientRepository.Filter(context)
            );
            Field<ListGraphType<OrderType>>("orders",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>{ Name = "id"},
                    new QueryArgument<ClientType>{ Name = "client"},
                    new QueryArgument<ListGraphType<ProductType>>{ Name = "products"}
                ),
                resolve: context => orderRepository.Filter(context)
            );
        }
    }
}