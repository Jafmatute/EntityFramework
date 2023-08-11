using System;
using System.Linq;

namespace Queries.Linq
{
    public static class LinqSyntax
    {
        private static PlutoContext Ctx { get; set; } = new PlutoContext();
        
        public static void Syntax()
        {
            //Linq syntax
            var query = from c in Ctx.Courses
                where c.Name.Contains("c#")
                orderby c.Name
                select c;


            foreach (var course in query) Console.WriteLine(course.Name);
        }

        public static void ExtensionMethod()
        {
            //Extension Method
            var courses = Ctx.Courses.Where(c => c.Name.Contains("c#")).OrderBy(c => c.Name);

            foreach (var course in courses) Console.WriteLine(course.Name);
        }

        public static void QueryOrdering()
        {
            var query = from c in Ctx.Courses
                where c.Author.Id == 1
                orderby c.Level descending, c.Name
                select c;
        }

        public static void QueryProjection()
        {
            var query = from c in Ctx.Courses
                where c.Author.Id == 1
                orderby c.Level descending, c.Name
                select new
                {
                    c.Name,
                    Author = c.Author.Name
                };
        }

        public static void QueryGrouping()
        {
            var query = from c in Ctx.Courses
                group c by c.Level
                into g
                select g;

            foreach (var group in query)
            {
                Console.WriteLine($@"{group.Key} ({group.Count()})");

                foreach (Course course in group)
                {
                    Console.WriteLine(@"   {0}", course.Name);
                }
            }
        }

        public static void QueryJoiningNavigation()
        {
            var query = from c in Ctx.Courses
                select new { CourseName = c.Name, AuthorName = c.Author.Name };
        }

        public static void QueryInnerJoin()
        {
            var query = from c in Ctx.Courses
                join a in Ctx.Authors on c.AuthorId equals a.Id
                select new { CourseName = c.Name, AuthorName = a.Name };
        }

        public static void QueryGroupJoin()
        {
            var query = from a in Ctx.Authors
                join c in Ctx.Courses on a.Id equals c.AuthorId into g
                select new { AuthorName = a.Name, Courses = g.Count() };

            foreach (var x in query)
            {
                Console.WriteLine(@"{0}-{1}", x.AuthorName, x.Courses);
            }
        }

        public static void QueryCrossJoin()
        {
            var query = from a in Ctx.Authors
                from c in Ctx.Courses
                select new { AuthorName = a.Name, CourseName = c.Name };

            foreach (var cross in query)
            {
                Console.WriteLine(@"{0} - {1}", cross.AuthorName, cross.CourseName);
            }
        }
    }
}