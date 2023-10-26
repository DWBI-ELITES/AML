using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{

    public class ExposureSummaryMoM
    {

        public string ExposureType { get; set; }
        public float? ExposureAmount { get; set; }
        public string Month { get; set; }
    }
}