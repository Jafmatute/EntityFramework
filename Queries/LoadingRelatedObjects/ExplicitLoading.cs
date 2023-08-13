using System;
using System.Data.Entity;
using System.Linq;

namespace Queries.LoadingRelatedObjects
{
    public static class ExplicitLoading
    {
        public static PlutoContext Ctx { get; set; } = new PlutoContext();
        
        public static void Explicit()
        {
            var query = Ctx.Authors.Single(c => c.Id == 1);
            
            //MSDN way => a single record
            Ctx.Entry(query).Collection(a=> a.Courses)
                .Query().Where(c=> c.FullPrice ==0)
                .Load();
            
            //Mosh way
            Ctx.Courses.Where(c=> c.AuthorId == query.Id && c.FullPrice==0)
                .Load();
            
            foreach (var course in query.Courses) Console.WriteLine(course.Name);
        }
        
        public static void ExplicitExample()
        {
            var authors = Ctx.Authors.ToList();
            var authorsId = authors.Select(a => a.Id);
            
            Ctx.Courses.Where(c=> authorsId.Contains(c.AuthorId) && c.FullPrice==0).Load();
        }
    }
}