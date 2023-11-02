using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{
    public class BranchModel
    {
        public string branch_id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string address_id { get; set; }
        public string phone_id { get; set; }
    }

}