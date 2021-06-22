using GraphQL.Types;

namespace WorkShop4.GraphQL.Types
{
    public class ProductInputType:InputObjectGraphType
    {
        public ProductInputType(){
            Name = "ProductInput";
            Field<IntGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<FloatGraphType>>("price");
            Field<NonNullGraphType<IntGraphType>>("quantity");
        }
    }
}