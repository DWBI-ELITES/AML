using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{
    public class Countries
    {
        [Key]
            public string CountryCode { get; set; }
            public string Country { get; set; }
       
    }
}