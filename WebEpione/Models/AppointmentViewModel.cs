using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class AppointmentViewModel
    {

        [Key]
        public int AppointmentId { get; set; }
        [Display(Name = "The Display Name")DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy H:mm:ss tt}"), DataType(DataType.DateTime)]
        public DateTime AppDate { get; set; }
        public int AppRate { get; set; }
        public string VisitReason { get; set; }
       // public Report Report { get; set; }
     //  public int ReportId { get; set; }
       public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
       public Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}