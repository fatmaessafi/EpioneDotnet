using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class StatViewModels
    {
        [Key]
        public int AppointmentId { get; set; }
        public string VisitReason { get; set; }
    }
}