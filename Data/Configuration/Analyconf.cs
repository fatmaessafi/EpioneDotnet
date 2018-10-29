using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class Analyconf : EntityTypeConfiguration<Analytics>
    {
        public Analyconf()
        {
            HasRequired<Doctor>(a => a.DoctorAnalytics).WithMany(t => t.ListAnalytics)
          .HasForeignKey(e => e.DoctorId).WillCascadeOnDelete(true);
        }
    }
}
