using Queries.LoadingRelatedObjects;
using Queries.UpdatingData;

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
            //ExplicitLoading.Explicit();
            // Console.ReadKey();
            
            /*Objects add, update and remove*/
            //Add.AddObjectWpf();
            //Update.UpdateObject();
            //Delete.DeleteObjectCascadeDisable();
            ChangeTracking.Tracking();
        }
    }
}