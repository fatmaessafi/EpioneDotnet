using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Report
    {
        public int ReportId { get; set; }
        public string ReportDescription { get; set; }
        public DateTime ReportDate { get; set; }
        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }
    }
}
