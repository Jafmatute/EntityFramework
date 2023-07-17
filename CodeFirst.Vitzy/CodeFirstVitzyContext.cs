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
    }
}
