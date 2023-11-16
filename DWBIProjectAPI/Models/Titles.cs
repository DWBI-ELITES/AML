using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{
    public class Titles
    {
        [Key]
        public string Title { get; set; }
    }

}