using System;
using System.Linq;

namespace Queries.Linq
{
    public static class LinqExtensionMethod
    {
        private static PlutoContext Ctx { get; set; } = new PlutoContext();

        public static void LinqRestriction()
        {
            var courses = Ctx.Courses
                .Where(c => c.Level == 1);
        }

        public static void LinqOrdering()
        {
            var courses = Ctx.Courses
                .Where(c => c.Level == 1).OrderBy(c => c.Name).ThenBy(c => c.Level);


            //Descending
            var coursesDeseThenBy = Ctx.Courses
                .Where(c => c.Level == 1).OrderByDescending(c => c.Name).ThenByDescending(c => c.Level);
        }

        public static void LinqProjection()
        {
            var projectionObj = Ctx.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name });

            var tag = Ctx.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .Select(c => c.Tags);

            foreach (var t in tag)
            {
                foreach (var course in t)
                {
                    Console.WriteLine(course.Name);
                }
            }

            var tagMany = Ctx.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .SelectMany(c => c.Tags);

            foreach (var t in tagMany)
            {
                Console.WriteLine(t.Name);
            }
        }

        public static void LinqSetOperator()
        {
            var tagMany = Ctx.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .SelectMany(c => c.Tags)
                .Distinct();

            foreach (var tag in tagMany)
            {
                Console.WriteLine(tag.Name);
            }
        }

        public static void LinqGrouping()
        {
            var groups = Ctx.Courses
                .GroupBy(c => c.Level);

            foreach (var group in groups)
            {
                Console.WriteLine($@"Key: {group.Key}");

                foreach (var course in group)
                {
                    Console.WriteLine(@"   {0}", course.Name);
                }
            } 
        }

        public static void LinqInnerJoin()
        {
            var join = Ctx.Courses
                .Join(Ctx.Authors, c => c.AuthorId, s => s.Id, 
                    (course, author) => new
                {
                    CourseName = course.Name,
                    AuthorName = author.Name
                });
        }
        
        public static void LinqGroupJoin()
        {
            var join = Ctx.Authors
                .GroupJoin(Ctx.Courses, a => a.Id,
                    c => c.AuthorId, (author, courses) => new
                    {
                        Author = author,
                        Courses = courses.Count(),
                    });

            foreach (var j in join)
            {
                Console.WriteLine($@"Author: {j.Author.Name} - Courses: {j.Courses}");
            }
        }

        public static void LinqCrossJoin()
        {
            var crossJoin = Ctx.Authors
                .SelectMany(a=> Ctx.Courses, (author, course) => new
                {
                    AuthorName = author.Name,
                    CourseName = course.Name
                });

            foreach (var crs in crossJoin)
            {
                Console.WriteLine(@"Author: {0} - Course: {1}", crs.AuthorName, crs.CourseName);
            }
        }
    }
}