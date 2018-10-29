using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Doctor : Person
    {
        public int DoctorId { get; set; }
        public string Speciality { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public Boolean Surgeon { get; set; }
        public ICollection<DayOff> ListDayOff { get; set; }
        public ICollection<Analytics> ListAnalytics { get; set; }
        public ICollection<VisitReason> ListVisitReason { get; set; }
        public ICollection<Message> ListMsg { get; set; }
        public ICollection<Appointment> ListApp { get; set; }


    }
}
