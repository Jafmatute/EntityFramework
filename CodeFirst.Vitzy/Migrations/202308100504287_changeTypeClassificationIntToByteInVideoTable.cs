namespace CodeFirst.Vitzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTypeClassificationIntToByteInVideoTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Videos", "classification", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videos", "classification", c => c.Int(nullable: false));
        }
    }
}
