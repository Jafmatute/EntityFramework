using System;
using System.Linq;

namespace Queries.Linq
{
    public static class DeferredExecution
    {
        public static PlutoContext Ctx { get; set; } = new PlutoContext();

        public static void ExecutionDb()
        {
            var courses = Ctx.Courses
                .Where(c => c.IsBeginnerCourse == true); //error
            
            var courses2 = Ctx.Courses.ToList()
                .Where(c => c.IsBeginnerCourse == true); 

            foreach (var course in courses2) Console.WriteLine(course.Name);

        }
    }
}