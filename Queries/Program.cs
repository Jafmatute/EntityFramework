
using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new PlutoContext();

            //Linq syntax
            var query = from c in ctx.Courses
                        where c.Name.Contains("c#")
                        orderby c.Name
                        select c;

            //foreach (var course in query) Console.WriteLine(course.Name);


            //Extension Method
            var courses = ctx.Courses.
                Where(c => c.Name.Contains("c#")).OrderBy(c => c.Name);

            foreach (var course in courses) Console.WriteLine(course.Name);

            Console.ReadKey();
        }
    }
}
