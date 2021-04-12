namespace RedBadgeProj.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dog", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Dog", "EventId");
            AddForeignKey("dbo.Dog", "EventId", "dbo.Event", "EventId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dog", "EventId", "dbo.Event");
            DropIndex("dbo.Dog", new[] { "EventId" });
            DropColumn("dbo.Dog", "EventId");
        }
    }
}
