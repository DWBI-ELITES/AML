using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{
    public class Signatory
    {
        public string account { get; set; }
        [Key]
        public string person_id { get; set; }
        public bool? primary_sig { get; set; }
        public string role { get; set; }
        public DateTime? update_date { get; set; }
        public string updated_by { get; set; }
    }

}