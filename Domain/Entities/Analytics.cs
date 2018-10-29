using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class Analytics
    {
        public int StatId { get; set; }
        public DateTime StatDate { get; set; }
        public int NbPatients { get; set; }
        public float CancelingRate { get; set; }
        public Doctor DoctorAnalytics { get; set; }
       

    }
}
