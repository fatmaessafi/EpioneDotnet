using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Step
    {
        [Key]
        public int StepId { get; set; }
        public string StepDescription { get; set; }
        public DateTime StepDate { get; set; }
        public Boolean Validation { get; set; }
        public int NbModifications { get; set; }
        public Doctor LastModificationBy { get; set; }
        public int DoctorId { get; set; }
        public DateTime LastModificationDate { get; set; }
        public string ModificationReason { get; set; }
        public Treatment Treatment { get; set; }
        public int TreatmentId { get; set; }

    }
}
