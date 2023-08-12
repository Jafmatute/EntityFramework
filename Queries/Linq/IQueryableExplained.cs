using System;
using System.Collections.Generic;
using System.Linq;

//IQueryable => extends consult
//IEnumerable  => not extends, save memory query

namespace Queries.Linq
{
    public static class IQueryableExplained
    {
        public static PlutoContext Ctx { get; set; } = new PlutoContext();
        
        public static void Iqueryable()
        {
            IQueryable<Course> courses = Ctx.Courses;
            var filtered = courses.Where(c => c.Level == 1);

            foreach (var course in filtered) Console.WriteLine(course.Name);
        }
        
        public static void Example()
        {
            IQueryable<Course> q;
            q.Where(c => c.Level == 1).OrderBy(c => c.Name);
            
            IEnumerable<Course> e;
            e.Where(c => c.Level == 1).OrderBy(c => c.Name);

        }
        
    }
}