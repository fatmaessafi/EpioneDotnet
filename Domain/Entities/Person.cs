using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public abstract class  Person
    {
        public int PersonId;
        public int Cin;
        public string LastName;
        public string FirstName;
        public string Gender;
        public DateTime BirthDate;
        public string HomeAddress { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string CivilStatus { get; set; }
        public Boolean Enabled { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
