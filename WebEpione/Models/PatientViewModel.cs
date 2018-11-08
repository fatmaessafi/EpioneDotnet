using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class PatientViewModel
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string CivilStatus { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Allergies { get; set; }
        public string Profession { get; set; }
        public string SpecialReq { get; set; }
    }
}