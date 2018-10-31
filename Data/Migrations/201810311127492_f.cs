namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
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
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
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
                        Surgeon = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        AppDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AppRate = c.Int(nullable: false),
                        VisitReason = c.String(),
                        ReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppointmentId, t.DoctorId, t.PatientId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
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
                    })
                .PrimaryKey(t => t.StepId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Treatments", t => t.TreatmentId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.TreatmentId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
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
                        Allergies = c.String(),
                        Profession = c.String(),
                        SpecialReq = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.MessageId, t.DoctorId, t.PatientId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        ReportDescription = c.String(),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AppointmentId = c.Int(nullable: false),
                        Appointment_AppointmentId = c.Int(nullable: false),
                        Appointment_DoctorId = c.Int(nullable: false),
                        Appointment_PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.Appointments", t => new { t.Appointment_AppointmentId, t.Appointment_DoctorId, t.Appointment_PatientId })
                .Index(t => new { t.Appointment_AppointmentId, t.Appointment_DoctorId, t.Appointment_PatientId });
            
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
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
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
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Treat",
                c => new
                    {
                        Appointment_AppointmentId = c.Int(nullable: false),
                        Appointment_DoctorId = c.Int(nullable: false),
                        Appointment_PatientId = c.Int(nullable: false),
                        Treatment_TreatmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Appointment_AppointmentId, t.Appointment_DoctorId, t.Appointment_PatientId, t.Treatment_TreatmentId })
                .ForeignKey("dbo.Appointments", t => new { t.Appointment_AppointmentId, t.Appointment_DoctorId, t.Appointment_PatientId }, cascadeDelete: true)
                .ForeignKey("dbo.Treatments", t => t.Treatment_TreatmentId, cascadeDelete: true)
                .Index(t => new { t.Appointment_AppointmentId, t.Appointment_DoctorId, t.Appointment_PatientId })
                .Index(t => t.Treatment_TreatmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analytics", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.VisitReasons", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DayOffs", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Reports", new[] { "Appointment_AppointmentId", "Appointment_DoctorId", "Appointment_PatientId" }, "dbo.Appointments");
            DropForeignKey("dbo.Messages", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Messages", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Treat", "Treatment_TreatmentId", "dbo.Treatments");
            DropForeignKey("dbo.Treat", new[] { "Appointment_AppointmentId", "Appointment_DoctorId", "Appointment_PatientId" }, "dbo.Appointments");
            DropForeignKey("dbo.Steps", "TreatmentId", "dbo.Treatments");
            DropForeignKey("dbo.Steps", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Treat", new[] { "Treatment_TreatmentId" });
            DropIndex("dbo.Treat", new[] { "Appointment_AppointmentId", "Appointment_DoctorId", "Appointment_PatientId" });
            DropIndex("dbo.VisitReasons", new[] { "DoctorId" });
            DropIndex("dbo.DayOffs", new[] { "DoctorId" });
            DropIndex("dbo.Reports", new[] { "Appointment_AppointmentId", "Appointment_DoctorId", "Appointment_PatientId" });
            DropIndex("dbo.Messages", new[] { "PatientId" });
            DropIndex("dbo.Messages", new[] { "DoctorId" });
            DropIndex("dbo.Steps", new[] { "TreatmentId" });
            DropIndex("dbo.Steps", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Analytics", new[] { "DoctorId" });
            DropTable("dbo.Treat");
            DropTable("dbo.VisitReasons");
            DropTable("dbo.DayOffs");
            DropTable("dbo.Reports");
            DropTable("dbo.Messages");
            DropTable("dbo.Patients");
            DropTable("dbo.Steps");
            DropTable("dbo.Treatments");
            DropTable("dbo.Appointments");
            DropTable("dbo.Doctors");
            DropTable("dbo.Analytics");
        }
    }
}
