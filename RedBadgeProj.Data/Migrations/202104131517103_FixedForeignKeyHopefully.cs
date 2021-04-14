namespace RedBadgeProj.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedForeignKeyHopefully : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dog", "EventId", "dbo.Event");
            DropIndex("dbo.Dog", new[] { "EventId" });
            AddColumn("dbo.Event", "DogId", c => c.Int(nullable: false));
            CreateIndex("dbo.Event", "DogId");
            AddForeignKey("dbo.Event", "DogId", "dbo.Dog", "DogId", cascadeDelete: true);
            DropColumn("dbo.Dog", "EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dog", "EventId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Event", "DogId", "dbo.Dog");
            DropIndex("dbo.Event", new[] { "DogId" });
            DropColumn("dbo.Event", "DogId");
            CreateIndex("dbo.Dog", "EventId");
            AddForeignKey("dbo.Dog", "EventId", "dbo.Event", "EventId", cascadeDelete: true);
        }
    }
}
