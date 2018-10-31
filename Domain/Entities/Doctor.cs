using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Doctor
    {

        [Key]
        public int DoctorId { get; set; }
        public int Cin { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; } 
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string HomeAddress { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string CivilStatus { get; set; }
        public Boolean Enabled { get; set; }
        public DateTime RegistrationDate { get; set; }
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
