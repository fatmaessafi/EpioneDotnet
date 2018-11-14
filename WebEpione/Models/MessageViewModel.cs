using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class MessageViewModel
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public Patient Patient { get; set; }
    }
}