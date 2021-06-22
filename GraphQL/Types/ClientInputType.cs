using GraphQL.Types;

namespace WorkShop4.GraphQL.Types
{
    public class ClientInputType: InputObjectGraphType
    {
        public ClientInputType(){
            Name = "ClientInput";
            Field<IntGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("website");
        }
    }
}