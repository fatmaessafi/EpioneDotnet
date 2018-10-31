using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpioneWeb.Models
{
    public enum GenderEnum { Male, Female }
    public enum CivilStatusEnum { Single, Married, Divorced }

    public class Users
    {   [Key]
        public int UserId { get; set; }
    
       
        public string Email { get; set; }

       
        public string Password { get; set; }

       
        public int Cin { get; set; }
    
        public string LastName { get; set; }
      
        public string FirstName { get; set; }
       
        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string HomeAddress { get; set; }

        public int Phone { get; set; }
   
        public string CivilStatus { get; set; }
       
       
    }
}