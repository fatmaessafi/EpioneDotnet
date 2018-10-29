using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class DoctorConfig : EntityTypeConfiguration<VisitReason>
    {
        public DoctorConfig()
        {
            HasRequired<Doctor>(a => a.DoctorVisitReason).WithMany(t => t.ListVisitReason)
             .HasForeignKey(e => e.DoctorVisitReason.DoctorId).WillCascadeOnDelete(true);

           
        }

    }
}
