using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DayOff
    {
        public int DayOffId { get; set; }
        public DateTime DayOffDate { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public Doctor DoctorDayOff { get; set; }

    }
}
