using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using WorkShop4.Models;

namespace WorkShop4.Repositories
{
    public class ProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }  
        public Product Find(long id){
            return _context.Products.Find(id);
        }
        public IEnumerable<Product> Filter(ResolveFieldContext<object> graphqlContext){
            var results = from products in _context.Products select products;
            if(graphqlContext.HasArgument("name")){
                var name = graphqlContext.GetArgument<string>("name");
                results = results.Where(c => c.name.Equals(name));
            }
            if(graphqlContext.HasArgument("price")){
                var price = graphqlContext.GetArgument<string>("price");
                results = results.Where(c => c.price.Equals(price));
            }
            if(graphqlContext.HasArgument("quantity")){
                var quantity = graphqlContext.GetArgument<string>("quantity");
                results = results.Where(c => c.quantity.Equals(quantity));
            }
            
            return results;
        }
        public Product Create(Product product){
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
    }
}