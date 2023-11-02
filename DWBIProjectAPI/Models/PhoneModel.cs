using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{
    public class PhoneModel
    {
        public string phone_id { get; set; }
        public string tph_contact_type { get; set; }
        public string tph_communication_type { get; set; }
        public string tph_country_prefix { get; set; }
        public string tph_extension { get; set; }
        public string tph_number { get; set; }
        public string comments { get; set; }
    }
}