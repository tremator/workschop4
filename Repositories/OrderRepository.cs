using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using WorkShop4.Models;

namespace WorkShop4.Repositories
{
    public class OrderRepository
    {
        private readonly DatabaseContext _context;
        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Order Order(long id){
            return _context.Orders.Find(id);
        }
        public Order Create(Order order){
            order.clientId = order.client.id;
            order.client = null;
            order.productsId = new List<long>();
            order.products.ForEach((product)=>{
                order.productsId.Add(product.id);
            });
            order.products = null;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }
        public Client GetClient(long id){
            var order = _context.Orders.Find(id);
            var client = _context.Clients.Find(order.clientId);
            return client;
        }
        public IEnumerable<Product> GetProducts(long id){
            return _context.Orders.Find(id).products;

        }
         public IEnumerable<Order> Filter(ResolveFieldContext<object> graphqlContext){
            var results = from orders in _context.Orders select orders;
            
            if(graphqlContext.HasArgument("id")){
                var id = graphqlContext.GetArgument<string>("id");
                results = results.Where(c => c.id.Equals(id));
            }
            var ordersx = results.ToList();
            List<Order> newList = new List<Order>();
            ordersx.ForEach((order) => {
                order.client = _context.Clients.Find(order.clientId);
                order.products = new List<Product>();
                order.productsId.ForEach((id) => {
                    var product = _context.Products.Find(id);
                    order.products.Add(product);
                });
                newList.Add(order);
            });
            return results;
        }
    }
}