namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class speciality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Steps", "StepSpeciality", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Steps", "StepSpeciality");
        }
    }
}
