using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class StepViewModel
    {
        public int StepId { get; set; }
        [Display(Name ="Step Speciality")]
        [EnumDataType(typeof(Speciality))]
        public string StepSpeciality { get; set; }
        [Display(Name = "Step Description")]

        public string StepDescription { get; set; }
        [Display(Name = "Step Date")]

        public DateTime StepDate { get; set; }
        [Display(Name = "Validation")]

        public string Validation { get; set; }
        [Display(Name = "Number of modifications")]

        public int NbModifications { get; set; }
        [Display(Name = "Last modification made by")]

        public string LastModificationBy { get; set; }
        [Display(Name = "Last modification date")]

        public string LastModificationDate { get; set; }
        [Display(Name = "Modification reason")]

        public string ModificationReason { get; set; }
        [Display(Name = "Illness")]

        public string TreatmentIllness { get; set; }
        public int TreatmentId { get; set; }
        public int AppointmentId { get; set; }
        [Display(Name = "Appointment")]

        public string Appointment { get; set; }

        //New step request

        public string NewStepDescription { get; set; }
        public string NewStepSpeciality { get; set; }
        public DateTime NewStepDate { get; set; }
        public string NewValidation { get; set; }
        public int NewLastModificationBy { get; set; }
        public DateTime NewLastModificationDate { get; set; }
        [Required]
        public string NewModificationReason { get; set; }

    }
}