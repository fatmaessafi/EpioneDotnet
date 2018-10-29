using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.configuration
{
    class DayOffconf : EntityTypeConfiguration<DayOff>
    {
        public DayOffconf()
        {
            HasRequired<Doctor>(a => a.DoctorDayOff).WithMany(t => t.ListDayOff)
         .HasForeignKey(e => e.DoctorDayOff.DoctorId).WillCascadeOnDelete(true);
        }
    }
}
