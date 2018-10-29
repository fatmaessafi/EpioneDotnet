using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class AppointmentConf : EntityTypeConfiguration<Appointment>
    {
        public AppointmentConf()
        {
            HasMany<Treatment>(a => a.ListTreatment).WithMany(t => t.ListAppointment)
                .Map(r => { r.ToTable("Treat");
                 r.MapLeftKey("TreatmentId");
                 r.MapRightKey("AppointmentId"); });
        }
    }
}
