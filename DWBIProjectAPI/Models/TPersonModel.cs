using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{
    public class TPersonModel
    {
        [Key]
        public string PERSONID { get; set; }
        public string birth_place { get; set; }
        public DateTime? birthdate { get; set; }
        public string cust_id { get; set; }
        public bool? deceased { get; set; }
        public DateTime? deceased_date { get; set; }
        public string email { get; set; }
        public string employer_name { get; set; }
        public string first_name { get; set; }
        public bool? foreigner { get; set; }
        public string identifier_code { get; set; }
        public string identifier_country { get; set; }
        public DateTime? identifier_expire_date { get; set; }
        public DateTime? identifier_issue_date { get; set; }
        public string identifier_issuer { get; set; }
        public string identifier_number { get; set; }
        public string identifier_other { get; set; }
        public string identifier_state { get; set; }
        public string issuer_id { get; set; }
        public string last_name { get; set; }
        public string lga_of_origin { get; set; }
        public string middle_name { get; set; }
        public string mothers_name { get; set; }
        public string nationality { get; set; }
        public string nok_address1 { get; set; }
        public string nok_address2 { get; set; }
        public string nok_email { get; set; }
        public string nok_name { get; set; }
        public string nok_phone { get; set; }
        public string nok_relationship { get; set; }
        public string occupation { get; set; }
        public string p_add_address1 { get; set; }
        public string p_add_address2 { get; set; }
        public string p_add_city { get; set; }
        public string p_add_country_code { get; set; }
        public string p_add_state { get; set; }
        public string p_add_zip { get; set; }
        public string p_alias { get; set; }
        public string passport_number { get; set; }
        public string passport_issue_country { get; set; }
        public string prefix_name { get; set; }
        public string RECORD_STATUS { get; set; }
        public string referee_person_id { get; set; }
        public string reference_code { get; set; }
        public string residence { get; set; }
        public string sex { get; set; }
        public string source_of_weqlth { get; set; }
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
        public string address_id { get; set; }
        public string phone_id { get; set; }
        public string addressType { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string town { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string country_code { get; set; }
        public string state { get; set; }
        public string tph_contact_type { get; set; }
        public string tph_country_prefix { get; set; }
        public string tph_number { get; set; }
        public string tph_extension { get; set; }
        public string tph_fax { get; set; }
        public string TPH_COMMUNICATION_TYPE { get; set; }
    }
}