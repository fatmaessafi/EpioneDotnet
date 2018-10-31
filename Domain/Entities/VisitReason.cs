using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class VisitReason
    {
        public int VRId { get; set; }
        public string VRDescription { get; set; }
        public Doctor DoctorVisitReason { get; set; }
        public int DoctorId { get; set; }


    }
}
