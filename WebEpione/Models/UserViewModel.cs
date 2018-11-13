using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public DateTime birthDate { get; set; }
        public String gender { get; set; }
        public String doctolibName { get; set; }
        public String doctolibAdress { get; set; }
        public String doctolibSpec { get; set; }
    }
}