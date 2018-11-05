using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    internal class StepConfig : EntityTypeConfiguration<Step>
    {
        public StepConfig()

        {   //One to One Appointment et Step
            HasRequired<Appointment>(t => t.Appointment).WithRequiredPrincipal(t => t.Step);
            // One to Many Treatment et Step
            HasRequired<Treatment>(a => a.Treatment).WithMany(t => t.ListSteps)
         .HasForeignKey(e => e.TreatmentId).WillCascadeOnDelete(true);
        }
    }
}