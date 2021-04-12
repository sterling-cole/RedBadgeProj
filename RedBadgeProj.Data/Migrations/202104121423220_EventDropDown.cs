namespace RedBadgeProj.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventDropDown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "ModifiedUtc");
        }
    }
}
