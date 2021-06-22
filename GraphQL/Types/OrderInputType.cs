using GraphQL.Types;
namespace WorkShop4.GraphQL.Types
{
    public class OrderInputType: InputObjectGraphType
    {
        public OrderInputType(){
            Name = "OrderInput";
            Field<NonNullGraphType<ClientInputType>>("client");
            Field<NonNullGraphType<ListGraphType<ProductInputType>>>("products");
        }
    }
}