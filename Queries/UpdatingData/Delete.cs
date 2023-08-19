using System.Linq;

namespace Queries.UpdatingData
{
    public static class Delete
    {
        private static PlutoContext Ctx { get; set; } = new PlutoContext();
        
        public static void DeleteObjectCascadeDisable()
        {
            var author = Ctx.Authors.Include("Courses")
                .Single(a => a.Id == 2);
            Ctx.Courses.RemoveRange(author.Courses);
            Ctx.Authors.Remove(author);
            Ctx.SaveChanges();


        }
        
        public static void DeleteObjectCascadeEnable()
        {
            var course = Ctx.Courses.Find(10);
            Ctx.Courses.Remove(course);
            Ctx.SaveChanges();   
        }
    }
}