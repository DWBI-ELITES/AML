using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{
    public class AddressModel
    {
        public string address_id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public int? house_number { get; set; }
        public int? apartment_number { get; set; }
        public string addresstype { get; set; }
        public string city { get; set; }
        public string country_code { get; set; }
        public string state { get; set; }
        public string town { get; set; }
        public string zip { get; set; }
        public string geo_location { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public string pluscode { get; set; }
        public bool? is_approx_location { get; set; }
        public string comments { get; set; }
    }
}