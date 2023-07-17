namespace CodeFirst.Vitzy.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddClassificationSilverGoldPlatinumFromVideoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Classification", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Videos", "Classification");
        }
    }
}
