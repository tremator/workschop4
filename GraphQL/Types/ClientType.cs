using GraphQL.Types;
using WorkShop4.Models;
using WorkShop4.Repositories;

namespace WorkShop4.GraphQL.Types
{
    public class ClientType: ObjectGraphType<Client>
    {
        public ClientType(ClientRepository repository){
            Name = "Client";
            Field(x => x.id);
            Field(x => x.name);
            Field(x => x.lastName);
            Field(x => x.email);
            Field(x => x.website);
        }
        

    }
}