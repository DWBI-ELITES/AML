using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{
    public class ExcelRecord
    {
        public string Name { get; set; }
        public int? Year { get; set; } // Use nullable int
        public string Category { get; set; }
        public string Limit { get; set; }
        public string ThresholdTarget { get; set; }
        public long? ordernumber { get; set; } // Use nullable long
        public string subCategory { get; set; }
        [Key]
        public int ID { get; set; }
        public string CategoryCode { get; set; }
    }
}



