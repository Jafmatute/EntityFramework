using CodeFirst.Vitzy.EntityConfigurations;
using System.Data.Entity;

namespace CodeFirst.Vitzy
{
    class CodeFirstVitzyContext : DbContext
    {
        public CodeFirstVitzyContext() : base("name=CodeFirstVitzy")
        {


        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
        }
    }
}
