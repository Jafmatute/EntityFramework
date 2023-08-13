using System;
using System.Linq;

namespace Queries.LoadingRelatedObjects
{
    public static class LazyLoading
    {
        public static PlutoContext Ctx { get; set; } = new PlutoContext();

        public static void Lazy()
        {
            var query = Ctx.Courses.Single(c => c.Id == 2);

            foreach (var tag in query.Tags) Console.WriteLine(tag.Name);

        }
    }
}