namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wael : DbMigration
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
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        City = c.String(),
                        HomeAddress = c.String(),
                        CivilStatus = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Speciality = c.String(),
                        Location = c.String(),
                        Surgeon = c.Boolean(),
                        Allergies = c.String(),
                        Profession = c.String(),
                        SpecialReq = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        AppDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AppRate = c.Int(nullable: false),
                        VisitReason = c.String(),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        StepId = c.Int(),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Steps", t => t.StepId)
                .Index(t => t.DoctorId)
                .Index(t => t.StepId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        TreatmentId = c.Int(nullable: false, identity: true),
                        Illness = c.String(),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Validation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TreatmentId)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        StepId = c.Int(nullable: false, identity: true),
                        StepDescription = c.String(),
                        StepSpeciality = c.String(),
                        StepDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Validation = c.Boolean(nullable: false),
                        NbModifications = c.Int(nullable: false),
                        LastModificationBy = c.Int(nullable: false),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationReason = c.String(),
                        TreatmentId = c.Int(nullable: false),
                        AppointmentId = c.Int(),
                    })
                .PrimaryKey(t => t.StepId)
                .ForeignKey("dbo.Treatments", t => t.TreatmentId, cascadeDelete: true)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId)
                .Index(t => t.TreatmentId)
                .Index(t => t.AppointmentId);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CustomRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CustomRole_Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false),
                        ReportDescription = c.String(),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
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
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StepRequests",
                c => new
                    {
                        NewStepId = c.Int(nullable: false, identity: true),
                        StepId = c.Int(nullable: false),
                        NewStepDescription = c.String(),
                        NewStepSpeciality = c.String(),
                        NewStepDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NewValidation = c.Boolean(nullable: false),
                        NewLastModificationBy = c.Int(nullable: false),
                        NewLastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NewModificationReason = c.String(),
                        NewTreatmentId = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.NewStepId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Analytics", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.VisitReasons", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.DayOffs", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.Steps", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Reports", "ReportId", "dbo.Appointments");
            DropForeignKey("dbo.Treatments", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.Steps", "TreatmentId", "dbo.Treatments");
            DropForeignKey("dbo.Appointments", "StepId", "dbo.Steps");
            DropForeignKey("dbo.Messages", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Users");
            DropIndex("dbo.VisitReasons", new[] { "DoctorId" });
            DropIndex("dbo.DayOffs", new[] { "DoctorId" });
            DropIndex("dbo.Reports", new[] { "ReportId" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "UserId" });
            DropIndex("dbo.CustomUserLogins", new[] { "UserId" });
            DropIndex("dbo.Steps", new[] { "AppointmentId" });
            DropIndex("dbo.Steps", new[] { "TreatmentId" });
            DropIndex("dbo.Treatments", new[] { "DoctorId" });
            DropIndex("dbo.Messages", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "StepId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.CustomUserClaims", new[] { "UserId" });
            DropIndex("dbo.Analytics", new[] { "DoctorId" });
            DropTable("dbo.StepRequests");
            DropTable("dbo.CustomRoles");
            DropTable("dbo.VisitReasons");
            DropTable("dbo.DayOffs");
            DropTable("dbo.Reports");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.Steps");
            DropTable("dbo.Treatments");
            DropTable("dbo.Messages");
            DropTable("dbo.Appointments");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Analytics");
        }
    }
}
