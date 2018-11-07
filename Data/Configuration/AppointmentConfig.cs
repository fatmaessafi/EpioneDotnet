﻿using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    class AppointmentConfig : EntityTypeConfiguration<Appointment>
    {
        public AppointmentConfig()
        {   
           
         

               // One to Many Doctor and Appointment
                HasRequired<Doctor>(a => a.Doctor).WithMany(t => t.ListAppointment)
              .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);

            // One to Many Patient and Appointment
            HasRequired<Patient>(a => a.Patient).WithMany(t => t.ListAppointment)
          .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);


        }
                
    }
}
