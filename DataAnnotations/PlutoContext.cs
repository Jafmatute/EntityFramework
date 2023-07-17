using System.Data.Entity;

namespace DataAnnotations
{
    public class PlutoContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Course> Courses { get; set; }

        public PlutoContext() : base("name=DataAnnotationContext")
        {

        }
    }
}