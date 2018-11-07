using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class AppointmentConfig : EntityTypeConfiguration<Appointment>
    {
        public AppointmentConfig()
        {   // Many to Many entre Appointment et Treatment
            HasMany<Treatment>(a => a.ListTreatment).WithMany(t => t.ListAppointment)
                .Map(r => { r.ToTable("Treat");
                   
                });

           
            // Report
         /*   HasOptional<Report>(t => t.Report).WithOptionalPrincipal(t => t.Appointment);

               // One to Many Doctor and Appointment
                HasOptional<Doctor>(a => a.Doctor).WithMany(t => t.ListAppointment)
              .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);

            // One to Many Patient and Appointment
            HasOptional<Patient>(a => a.Patient).WithMany(t => t.ListAppointment)
          .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);
          */


        }
                
    }
}
