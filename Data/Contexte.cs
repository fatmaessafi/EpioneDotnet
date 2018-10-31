using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Contexte : DbContext
    {
        public DbSet<Patient> Patient { set; get; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Analytics> Analytics { set; get; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<DayOff> DayOff { set; get; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Step> Step { set; get; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<VisitReason> VisitReason { set; get; }
     
        public Contexte() : base("name=EpioneDB")
        {
               
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Table - per - Concrete - Type(TPC)
            modelBuilder.Entity<Patient>().Map(a => { a.MapInheritedProperties(); a.ToTable("Patient"); });
            modelBuilder.Entity<Doctor>().Map(a => { a.MapInheritedProperties(); a.ToTable("Doctor"); });

            //Fluent API Configurations
            modelBuilder.Configurations.Add(new Configuration.AnalyticsConfig());
            modelBuilder.Configurations.Add(new Configuration.DoctorConfig());
            modelBuilder.Configurations.Add(new Configuration.DayOffConfig());
            modelBuilder.Configurations.Add(new Configuration.DoctorConfig());
            modelBuilder.Configurations.Add(new Configuration.MessageConfig());
            modelBuilder.Configurations.Add(new Configuration.PersonConfig());
            modelBuilder.Configurations.Add(new Configuration.StepConfig());
            modelBuilder.Configurations.Add(new Configuration.VisitReasonConfig());


        }
    }
   
}

