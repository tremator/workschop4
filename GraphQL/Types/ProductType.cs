using GraphQL.Types;
using WorkShop4.Models;
using WorkShop4.Repositories;


namespace WorkShop4.GraphQL.Types
{
    public class ProductType: ObjectGraphType<Product>
    {
        public ProductType(ProductRepository repository){
            Name = "Product";
            Field(x => x.id);
            Field(x => x.name);
            Field(x => x.price);
            Field(x => x.quantity);
            Field<ListGraphType<ClientType>>(
                "Product", 
                resolve: context => {
                    return repository.Find(context.Source.id);
                }
            );
            
        }
    }
}