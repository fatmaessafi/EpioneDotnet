﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public string ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public DateTime ReportDate { get; set; }
        public Step Step { get; set; }
        public string ReportImage { get; set; }
    }
}
