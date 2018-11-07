namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Treatments", "Appointment_AppointmentId", "dbo.Appointments");
            DropIndex("dbo.Treatments", new[] { "Appointment_AppointmentId" });
            DropColumn("dbo.Treatments", "Appointment_AppointmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Treatments", "Appointment_AppointmentId", c => c.Int());
            CreateIndex("dbo.Treatments", "Appointment_AppointmentId");
            AddForeignKey("dbo.Treatments", "Appointment_AppointmentId", "dbo.Appointments", "AppointmentId");
        }
    }
}
