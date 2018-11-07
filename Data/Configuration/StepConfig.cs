using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    internal class StepConfig : EntityTypeConfiguration<Step>
    {
        public StepConfig()

<<<<<<< HEAD


        {      // Report One to One
            HasOptional<Report>(t => t.Report).WithOptionalPrincipal(t => t.Step);
            //One to One Appointment et Step
            HasRequired<Appointment>(t => t.Appointment).WithRequiredPrincipal(t => t.Step);
=======
        {   //One to One Appointment et Step
            HasOptional<Appointment>(t => t.Appointment).WithOptionalPrincipal(t => t.Step);
>>>>>>> master
            // One to Many Treatment et Step
            HasRequired<Treatment>(a => a.Treatment).WithMany(t => t.ListSteps)
         .HasForeignKey(e => e.TreatmentId).WillCascadeOnDelete(false);
        }
    }
}