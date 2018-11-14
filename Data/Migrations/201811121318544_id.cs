namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StepRequests", "StepId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StepRequests", "StepId");
        }
    }
}
