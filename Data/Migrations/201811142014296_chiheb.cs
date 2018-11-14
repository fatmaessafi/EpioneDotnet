namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chiheb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        End = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ThemeColor = c.String(),
                        IsFullDay = c.Byte(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "DoctorId", "dbo.Users");
            DropIndex("dbo.Events", new[] { "DoctorId" });
            DropTable("dbo.Events");
        }
    }
}
