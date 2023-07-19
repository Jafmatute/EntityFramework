using FluentAPI.EntityConfigurations;
using System.Data.Entity;

namespace FluentAPI
{
    class FluentAPIContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public FluentAPIContext() : base("name=FluentAPIContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
}
