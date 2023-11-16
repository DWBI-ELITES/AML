using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{
    public class Customer
    {
        [Key]
        public string cust_id { get; set; }
        public string addressId { get; set; }
        public string birth_place { get; set; }
        public DateTime? birthdate { get; set; }
        public int? business { get; set; }
        public int? business_closed { get; set; }
        public DateTime? business_closed_date { get; set; }
        public long? bvn { get; set; }
        public string commercial_name { get; set; }
        public string cust_sex { get; set; }
        public string cust_type_code { get; set; }
        public string customer_type { get; set; }
        public string email { get; set; }
        public string employer_name { get; set; }
        public string first_name { get; set; }
        public int? foreigner { get; set; }
        public string incorporation_country_code { get; set; }
        public DateTime? incorporation_date { get; set; }
        public string incorporation_number { get; set; }
        public string incorporation_state { get; set; }
        public int? issuer_id { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string mothers_name { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public int? nature_of_txn { get; set; }
        public string occupation { get; set; }
        public string phoneId { get; set; }
        public string prefix_name { get; set; }
        public string referee_person_id { get; set; }
        public string reference_code { get; set; }
        public string residence { get; set; }
        public string sex { get; set; }
        public string source_of_fund { get; set; }
        public string ssn { get; set; }
        public DateTime? foreigner_date_arrival { get; set; }
        public string foreigner_nationality { get; set; }
        public DateTime? foreigner_passport_exp_dt { get; set; }
        public DateTime? foreigner_passport_iss_dt { get; set; }
        public string foreigner_passport_number { get; set; }
        public string foreigner_permit_number { get; set; }
        public DateTime? foreigner_permit_valid_from { get; set; }
        public DateTime? foreigner_permit_valid_to { get; set; }
        public string foreigner_visa_number { get; set; }
        public string tax_comments { get; set; }
        public string tax_number { get; set; }
        public string tax_reg_number { get; set; }
        public string title { get; set; }
        public DateTime? update_date { get; set; }
        public string updated_by { get; set; }
        public string work_dir { get; set; }
        public string addressType { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string town { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string country_code { get; set; }
        public string state { get; set; }
        public string tph_contact_type { get; set; }
        public string tph_communication_type { get; set; }
        public string tph_country_prefix { get; set; }
        public string tph_number { get; set; }
        public string tph_extension { get; set; }
        public string tph_fax { get; set; }
    }
}