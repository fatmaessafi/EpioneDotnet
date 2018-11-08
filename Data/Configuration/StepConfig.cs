using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    internal class StepConfig : EntityTypeConfiguration<Step>
    {
        public StepConfig()

        {   

            
            // One to Many Treatment et Step
            HasRequired<Treatment>(a => a.Treatment).WithMany(t => t.ListSteps)
         .HasForeignKey(e => e.TreatmentId).WillCascadeOnDelete(false);
        }
    }
}