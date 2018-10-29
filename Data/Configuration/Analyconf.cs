using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.configuration
{
    class Analyconf : EntityTypeConfiguration<Analytics>
    {
        public Analyconf()
        {
            HasRequired<Doctor>(a => a.Doctoranalytics).WithMany(t => t.ListAnalytics)
          .HasForeignKey(e => e.Doctoranalytics.DoctorId).WillCascadeOnDelete(true);
        }
    }
}
