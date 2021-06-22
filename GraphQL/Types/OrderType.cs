using GraphQL.Types;
using WorkShop4.Models;
using WorkShop4.Repositories;

namespace WorkShop4.GraphQL.Types
{
    public class OrderType: ObjectGraphType<Order>
    {
        public OrderType(OrderRepository repository){
            Name = "Order";
            Field(x => x.id);
            Field<ClientType>(
                "Client", 
                resolve: context => {
                    return repository.GetClient(context.Source.id);
                }
            );
            Field<ListGraphType<ProductType>>(
                "Products", 
                resolve: context => {
                    return repository.GetProducts(context.Source.id);
                }
            );
        }
    }
}