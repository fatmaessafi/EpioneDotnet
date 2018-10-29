using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.configuration
{
    class StepConf : EntityTypeConfiguration<Step>
    {
        public StepConf()
        {

            HasRequired<Treatment>(a => a.Treatment).WithMany(t => t.ListSteps)
         .HasForeignKey(e => e.Treatment.tratmentID).WillCascadeOnDelete(true);
        }
    }
}
