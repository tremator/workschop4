using GraphQL;
using GraphQL.Types;

namespace WorkShop4.GraphQL
{
    public class ProjectSchema:Schema
    {
        public ProjectSchema(IDependencyResolver resolver): base(resolver){
            Query = resolver.Resolve<ProjectQuery>();
            Mutation = resolver.Resolve<ProjectMutation>();
        }
    }
}