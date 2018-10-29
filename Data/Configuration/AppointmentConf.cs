using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.configuration
{
    class AppointmentConf : EntityTypeConfiguration<Appointment>
    {
        public AppointmentConf()
        {
            HasMany<Treatment>(a => a.listTreatment).WithMany(t => t.listAppointment)
                .Map(r => { r.ToTable("treat");
                 r.MapLeftKey("tratmentID");
                 r.MapRightKey("AppointmentId"); });
        }
    }
}
