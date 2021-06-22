using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using WorkShop4.Models;

namespace WorkShop4.Repositories
{
    public class ClientRepository
    {
        private readonly DatabaseContext _context;
        public ClientRepository(DatabaseContext context)
        {
            _context = context;
        }  
        public IEnumerable<Client> Filter(ResolveFieldContext<object> graphqlContext){
            var results = from clients in _context.Clients select clients;
            if(graphqlContext.HasArgument("name")){
                var name = graphqlContext.GetArgument<string>("name");
                results = results.Where(c => c.name.Equals(name));
            }
            if(graphqlContext.HasArgument("lastName")){
                var lastName = graphqlContext.GetArgument<string>("lastName");
                results = results.Where(c => c.lastName.Equals(lastName));
            }
            if(graphqlContext.HasArgument("email")){
                var email = graphqlContext.GetArgument<string>("email");
                results = results.Where(c => c.email.Equals(email));
            }
            if(graphqlContext.HasArgument("website")){
                var website = graphqlContext.GetArgument<string>("website");
                results = results.Where(c => c.website.Equals(website));
            }
            if(graphqlContext.HasArgument("id")){
                var id = graphqlContext.GetArgument<string>("id");
                results = results.Where(c => c.id.Equals(id));
            }
            return results;
        }
        public Client Find(long id){
            return _context.Clients.Find(id);
        }
        public Client Create(Client client){
            _context.Clients.Add(client);
            _context.SaveChanges();
            return client;
        }


    }
}