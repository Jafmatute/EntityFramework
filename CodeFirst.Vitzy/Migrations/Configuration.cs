namespace CodeFirst.Vitzy.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst.Vitzy.CodeFirstVitzyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirst.Vitzy.CodeFirstVitzyContext context)
        {
            // context.Genres.AddOrUpdate(
            //     g => g.Name, new Genre()
            //     {
            //         Name = "Action",
            //         Videos = new List<Video>()
            //         {
            //             new Video(){Name = "Rapidius and furios", ReleaseDate = DateTime.Now}
            //         }
            //     }
            // );
        }
    }
}
