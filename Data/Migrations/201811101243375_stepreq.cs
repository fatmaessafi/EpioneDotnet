namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stepreq : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StepRequests",
                c => new
                    {
                        NewStepId = c.Int(nullable: false, identity: true),
                        NewStepDescription = c.String(),
                        NewStepSpeciality = c.String(),
                        NewStepDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NewValidation = c.Boolean(nullable: false),
                        NewLastModificationBy = c.Int(nullable: false),
                        NewLastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NewModificationReason = c.String(),
                        NewTreatmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewStepId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StepRequests");
        }
    }
}
