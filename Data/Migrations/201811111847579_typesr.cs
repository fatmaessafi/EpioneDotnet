namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typesr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StepRequests", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StepRequests", "Type");
        }
    }
}
