namespace RedBadgeProj.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreForeignKeyStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owner",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateIndex("dbo.Dog", "OwnerId");
            AddForeignKey("dbo.Dog", "OwnerId", "dbo.Owner", "OwnerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dog", "OwnerId", "dbo.Owner");
            DropIndex("dbo.Dog", new[] { "OwnerId" });
            DropTable("dbo.Owner");
        }
    }
}
