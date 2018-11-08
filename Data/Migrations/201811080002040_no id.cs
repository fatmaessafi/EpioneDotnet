namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Steps", "Doctor_Id", "dbo.Users");
            DropIndex("dbo.Steps", new[] { "Doctor_Id" });
            DropColumn("dbo.Steps", "Doctor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Steps", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.Steps", "Doctor_Id");
            AddForeignKey("dbo.Steps", "Doctor_Id", "dbo.Users", "Id");
        }
    }
}
