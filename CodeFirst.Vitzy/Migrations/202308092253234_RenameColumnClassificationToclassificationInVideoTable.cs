namespace CodeFirst.Vitzy.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenameColumnClassificationToclassificationInVideoTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Videos", "Classification", "classification");
        }

        public override void Down()
        {
            RenameColumn("dbo.Videos", "classification", "Classification");
        }
    }
}
