namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Steps", "TreatmentId", "dbo.Treatments");
            AddForeignKey("dbo.Steps", "TreatmentId", "dbo.Treatments", "TreatmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Steps", "TreatmentId", "dbo.Treatments");
            AddForeignKey("dbo.Steps", "TreatmentId", "dbo.Treatments", "TreatmentId");
        }
    }
}
