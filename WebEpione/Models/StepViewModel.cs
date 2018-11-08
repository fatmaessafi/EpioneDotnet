using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class StepViewModel
    {
        public int StepId { get; set; }
        public string StepDescription { get; set; }
        public DateTime StepDate { get; set; }
        public string Validation { get; set; }
        public int NbModifications { get; set; }
        public string LastModificationBy { get; set; }
        public string LastModificationDate { get; set; }
        public string ModificationReason { get; set; }
        public string TreatmentIllness { get; set; }
        public int TreatmentId { get; set; }
    }
}