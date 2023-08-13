using Queries.LoadingRelatedObjects;

namespace Queries
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // LinqSyntax.QueryGrouping();
            // LinqExtensionMethod.LinqCrossJoin();
            // LinqExtensionMethodAdditional.Aggregating();
            // DeferredExecution.ExecutionDb();
            // IQueryableExplained.Iqueryable();
            
            /*Loading*/
            //LazyLoading.Lazy();
            //Problem_N_Mas_1.Problem();
            //EagerLoading.Eager();
            ExplicitLoading.Explicit();
            // Console.ReadKey();
        }
    }
}