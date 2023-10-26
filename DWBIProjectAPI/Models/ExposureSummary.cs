using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{

    public class ExposureSummary
    {
        public string ExposureType { get; set; }
        public string ExposureAmount { get; set; }
        public DateTime? ProcessingDate { get; set; }
    }
}