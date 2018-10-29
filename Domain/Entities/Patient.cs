using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Patient  : Person
    {
        public int PatientId { get; set; }
        public string Allergies { get; set; }
        public string Profession { get; set; }
        public string SpecialReq { get; set; }
        public ICollection<Message> ListMsgs { get; set; }
        public ICollection<Appointment> ListApps { get; set; }
    }
}
