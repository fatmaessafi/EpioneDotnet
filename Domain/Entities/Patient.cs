using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
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
        public string Allergies { get; set; }
        public string Profession { get; set; }
        public string SpecialReq { get; set; }
        public ICollection<Message> ListMsgs { get; set; }
        public ICollection<Appointment> ListApps { get; set; }
    }
}
