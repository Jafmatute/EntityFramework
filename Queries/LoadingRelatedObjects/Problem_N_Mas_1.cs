using System;
using System.Linq;

namespace Queries.LoadingRelatedObjects
{
    public static class Problem_N_Mas_1
    {
        public static PlutoContext Ctx { get; set; } = new PlutoContext();
        public static void Problem()
        {
            var courses = Ctx.Courses.ToList();

            foreach (var course in courses)
            {
                Console.WriteLine(@"{0} by {1}", course.Name, course.Author.Name);
            }
        }
    }
}