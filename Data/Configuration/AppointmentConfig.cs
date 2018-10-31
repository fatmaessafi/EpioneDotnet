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
                 r.MapLeftKey("TreatmentId");
                 r.MapRightKey("AppointmentId"); });

            //Table porteuse
            HasKey(a => new { a.AppointmentId, a.DoctorId, a.PatientId });
            // Report
            HasRequired<Report>(t => t.Report).WithRequiredPrincipal(t => t.Appointment);

        }
    }
}
