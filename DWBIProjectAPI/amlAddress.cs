//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DWBIProjectAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class amlAddress
    {
        public string address_id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public Nullable<int> house_number { get; set; }
        public Nullable<int> apartment_number { get; set; }
        public string addresstype { get; set; }
        public string city { get; set; }
        public string country_code { get; set; }
        public string state { get; set; }
        public string town { get; set; }
        public string zip { get; set; }
        public string geo_location { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public Nullable<decimal> longitude { get; set; }
        public string pluscode { get; set; }
        public Nullable<bool> is_approx_location { get; set; }
        public string comments { get; set; }
    }
}
