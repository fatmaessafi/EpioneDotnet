
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEpione.Models
{
    public class ReportViewModels
    {
        [Key]
        public int ReportId { get; set; }
        [Required]
        public string ReportTitle { get; set; }
        [Required]
        public string ReportDescription { get; set; }
        public DateTime ReportDate { get; set; }
        public Step Step { get; set; }
        [Required]
        public string ReportImage { get; set; }
    }
}