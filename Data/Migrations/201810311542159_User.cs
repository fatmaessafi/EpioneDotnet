namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analytics",
                c => new
                    {
                        StatId = c.Int(nullable: false, identity: true),
                        StatDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NbPatients = c.Int(nullable: false),
                        CancelingRate = c.Single(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatId)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Cin = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HomeAddress = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        CivilStatus = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Speciality = c.String(),
                        City = c.String(),
                        Location = c.String(),
                        Surgeon = c.Boolean(),
                        Allergies = c.String(),
                        Profession = c.String(),
                        SpecialReq = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        AppDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AppRate = c.Int(nullable: false),
                        VisitReason = c.String(),
                        ReportId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        TreatmentId = c.Int(nullable: false, identity: true),
                        Illness = c.String(),
                    })
                .PrimaryKey(t => t.TreatmentId);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        StepId = c.Int(nullable: false, identity: true),
                        StepDescription = c.String(),
                        StepDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Validation = c.Boolean(nullable: false),
                        NbModifications = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationReason = c.String(),
                        TreatmentId = c.Int(nullable: false),
                        LastModificationBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.StepId)
                .ForeignKey("dbo.Users", t => t.LastModificationBy_UserId)
                .ForeignKey("dbo.Treatments", t => t.TreatmentId, cascadeDelete: true)
                .Index(t => t.TreatmentId)
                .Index(t => t.LastModificationBy_UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false),
                        ReportDescription = c.String(),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AppointmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.Appointments", t => t.ReportId)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.DayOffs",
                c => new
                    {
                        DayOffId = c.Int(nullable: false, identity: true),
                        DayOffDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StartHour = c.Int(nullable: false),
                        EndHour = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DayOffId)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.VisitReasons",
                c => new
                    {
                        VRId = c.Int(nullable: false, identity: true),
                        VRDescription = c.String(),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VRId)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Treat",
                c => new
                    {
                        Appointment_AppointmentId = c.Int(nullable: false),
                        Treatment_TreatmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Appointment_AppointmentId, t.Treatment_TreatmentId })
                .ForeignKey("dbo.Appointments", t => t.Appointment_AppointmentId, cascadeDelete: true)
                .ForeignKey("dbo.Treatments", t => t.Treatment_TreatmentId, cascadeDelete: true)
                .Index(t => t.Appointment_AppointmentId)
                .Index(t => t.Treatment_TreatmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analytics", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.VisitReasons", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.DayOffs", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.Reports", "ReportId", "dbo.Appointments");
            DropForeignKey("dbo.Messages", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.Treat", "Treatment_TreatmentId", "dbo.Treatments");
            DropForeignKey("dbo.Treat", "Appointment_AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Steps", "TreatmentId", "dbo.Treatments");
            DropForeignKey("dbo.Steps", "LastModificationBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Users");
            DropIndex("dbo.Treat", new[] { "Treatment_TreatmentId" });
            DropIndex("dbo.Treat", new[] { "Appointment_AppointmentId" });
            DropIndex("dbo.VisitReasons", new[] { "DoctorId" });
            DropIndex("dbo.DayOffs", new[] { "DoctorId" });
            DropIndex("dbo.Reports", new[] { "ReportId" });
            DropIndex("dbo.Messages", new[] { "DoctorId" });
            DropIndex("dbo.Steps", new[] { "LastModificationBy_UserId" });
            DropIndex("dbo.Steps", new[] { "TreatmentId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Analytics", new[] { "DoctorId" });
            DropTable("dbo.Treat");
            DropTable("dbo.VisitReasons");
            DropTable("dbo.DayOffs");
            DropTable("dbo.Reports");
            DropTable("dbo.Messages");
            DropTable("dbo.Steps");
            DropTable("dbo.Treatments");
            DropTable("dbo.Appointments");
            DropTable("dbo.Users");
            DropTable("dbo.Analytics");
        }
    }
}
