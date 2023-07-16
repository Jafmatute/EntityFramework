using System.Collections.Generic;

namespace CodeFirstExistingDatabase.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstExistingDatabase.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirstExistingDatabase.PlutoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Authors.AddOrUpdate(a => a.Name, new Author()
            {
                Name = "Fernando Herrera",
                Courses = new List<Course>()
                {
                    new Course(){Name = "React de 0 a experto", Description = "React JS"}
                }
            });
        }
    }
}
