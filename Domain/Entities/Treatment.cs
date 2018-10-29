using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Treatment
    {
        public int TreatmentId { get; set; }
        public string Illness { get; set; }
        public  ICollection<Step> ListSteps { get; set; }
        public virtual ICollection<Appointment> ListAppointment { get; set; }


    }
}
