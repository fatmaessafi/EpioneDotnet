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

        public int var { get; set; }
        public int varp { get; set; }
        public int app { get; set; }
        public float vart { get; set; }
        public float varm { get; set; }

    }
}