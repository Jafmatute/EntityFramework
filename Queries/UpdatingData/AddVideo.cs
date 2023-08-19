using System.Linq;

namespace Queries.UpdatingData
{
    public static class AddVideo
    {
        public static PlutoContext Ctx { get; set; } = new PlutoContext();

        public static void AddObject()
        {
            var course = new Course
            {
                Name = "Clean Code",
                Description = "Clean",
                Level = 1,
                FullPrice = 19.95f,
                Author = new Author() {Id = 1, Name = "Mosh"}
            };

            Ctx.Courses.Add(course);

            Ctx.SaveChanges();
        }
        
        public static void AddObjectWpf()
        {
            var authors = Ctx.Authors.ToList();

            var author = authors.Single(a => a.Id == 1);
            
            var course = new Course
            {
                Name = "Clean Code",
                Description = "Clean",
                Level = 1,
                FullPrice = 19.95f,
                Author = author
            };

            Ctx.Courses.Add(course);

            Ctx.SaveChanges();
        }
        
        public static void AddObjectWeb()
        {
            var course = new Course
            {
                Name = "Xamarin app movile",
                Description = "movil app desing",
                Level = 1,
                FullPrice = 19.95f,
                AuthorId = 1
            };

            Ctx.Courses.Add(course);

            Ctx.SaveChanges();
        }
    }
}