namespace CodeFirst.Vitzy.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES ('Horror')");
            Sql("INSERT INTO Genres(Name) VALUES ('Actions')");
            Sql("INSERT INTO Genres(Name) VALUES ('Romance')");
            Sql("INSERT INTO Genres(Name) VALUES ('Others')");

        }

        public override void Down()
        {
            Sql("DELETE FROM Genres");
        }
    }
}
