using System;
using System.Data.Entity;
using System.Linq;

namespace Queries.LoadingRelatedObjects
{
    public static class EagerLoading
    {
        public static PlutoContext Ctx { get; set; } = new PlutoContext();
        
        public static void Eager()
        {
            var courses = Ctx.Courses.Include(c=> c.Author).ToList();

            //For single properties
           // Ctx.Courses.Include(C => C.Author.Address);
           
           //For collection properties
           //Ctx.Courses.Include(a => a.Tags.Select(t => t.Moderator));
           
           //To many Includes
           // Ctx.Courses
           //     .Include(c => c.Author.Name)
           //     .Include(a => a.Tags.Select(t => t.Id))
           //     .Include(c=> c.Author)
           //     .Include(c => c.Cover);
            
            foreach (var course in courses)
            {
                Console.WriteLine(@"{0} by {1}", course.Name, course.Author.Name);
            }
        }
    }
}