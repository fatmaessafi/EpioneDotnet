﻿using BibData.Conventions;
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
        
        public Contexte() : base("name=EpioneDB")
        {
               
        }
        //DbSets
        public DbSet<Patient> Patient { set; get; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Analytics> Analytics { set; get; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<DayOff> DayOff { set; get; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Step> Step { set; get; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<VisitReason> VisitReason { set; get; }

        //On ModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            //Fluent API Configurations
            modelBuilder.Configurations.Add(new Configuration.AnalyticsConfig());
            modelBuilder.Configurations.Add(new Configuration.AppointmentConfig());
            modelBuilder.Configurations.Add(new Configuration.DayOffConfig());
            modelBuilder.Configurations.Add(new Configuration.DoctorConfig());
            modelBuilder.Configurations.Add(new Configuration.MessageConfig());
            modelBuilder.Configurations.Add(new Configuration.StepConfig());
            modelBuilder.Configurations.Add(new Configuration.VisitReasonConfig());

            //Add Convention
          
            modelBuilder.Conventions.Add(new DateTimeConvention());

        }
    }
   
}

