using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DWBIProjectAPI.Models
{
    public class AccountModel
    {
        public string account { get; set; }
        public string account_officer { get; set; }
        public string account_ownership { get; set; }
        public string account_type { get; set; }
        public decimal? balance { get; set; }
        public DateTime? balance_date { get; set; }
        public string branch { get; set; }
        public string cust_number { get; set; }
        public DateTime? closed { get; set; }
        public string comments { get; set; }
        public string currency_code { get; set; }
        public string entity_cre_flg { get; set; }
        public string iban { get; set; }
        public string name { get; set; }
        public string new_account { get; set; }
        public DateTime? opened { get; set; }
        public string previous_status { get; set; }
        public string schm_code { get; set; }
        public string schm_type { get; set; }
        public string status { get; set; }
        public DateTime? status_date { get; set; }
        public string swift { get; set; }
        public string temp_account { get; set; }
        public string frez_reason_code { get; set; }
        public DateTime? acct_cls_date { get; set; }
        public string acct_cls_flg { get; set; }
        public decimal? clr_bal_amt { get; set; }
        public decimal? cum_cr_amt { get; set; }
        public decimal? cum_dr_amt { get; set; }
        public decimal? drwng_power { get; set; }
        public string frez_code { get; set; }
        public decimal? last_tran_date_cr { get; set; }
        public decimal? last_tran_date_dr { get; set; }
        public decimal? fx_cum_cr_amt { get; set; }
        public decimal? fx_cum_dr_amt { get; set; }
        public decimal? sanct_lim { get; set; }
        public DateTime? last_tran_date { get; set; }
    }

}