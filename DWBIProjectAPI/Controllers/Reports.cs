using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace DWBIProjectAPI.Controllers
{
    public class Reports
    {


        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class report
        {

            private string schema_versionField;

            private byte rentity_idField;

            private string rentity_branchField;

            private string submission_codeField;

            private string report_codeField;

            private System.DateTime report_dateField;

            private string currency_code_localField;

            public TPersonRegistrationInReport reporting_personField { get; set; }

            private string reporting_user_codeField;

            private reportLocation locationField;

            private reportTransaction[] transactionField;

            private string[] report_indicatorsField;

            /// <remarks/>
            public string schema_version
            {
                get
                {
                    return this.schema_versionField;
                }
                set
                {
                    this.schema_versionField = value;
                }
            }

            /// <remarks/>
            public byte rentity_id
            {
                get
                {
                    return this.rentity_idField;
                }
                set
                {
                    this.rentity_idField = value;
                }
            }

            /// <remarks/>
            public string rentity_branch
            {
                get
                {
                    return this.rentity_branchField;
                }
                set
                {
                    this.rentity_branchField = value;
                }
            }

            /// <remarks/>
            public string submission_code
            {
                get
                {
                    return this.submission_codeField;
                }
                set
                {
                    this.submission_codeField = value;
                }
            }

            /// <remarks/>
            public string report_code
            {
                get
                {
                    return this.report_codeField;
                }
                set
                {
                    this.report_codeField = value;
                }
            }

            /// <remarks/>
            public System.DateTime report_date
            {
                get
                {
                    return this.report_dateField;
                }
                set
                {
                    this.report_dateField = value;
                }
            }

            /// <remarks/>
            public string currency_code_local
            {
                get
                {
                    return this.currency_code_localField;
                }
                set
                {
                    this.currency_code_localField = value;
                }
            }

            /// <remarks/>
            public string reporting_user_code
            {
                get
                {
                    return this.reporting_user_codeField;
                }
                set
                {
                    this.reporting_user_codeField = value;
                }
            }

            /// <remarks/>
            public reportLocation location
            {
                get
                {
                    return this.locationField;
                }
                set
                {
                    this.locationField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("transaction")]
            public reportTransaction[] transaction
            {
                get
                {
                    return this.transactionField;
                }
                set
                {
                    this.transactionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("indicator", IsNullable = false)]
            public string[] report_indicators
            {
                get
                {
                    return this.report_indicatorsField;
                }
                set
                {
                    this.report_indicatorsField = value;
                }
            }
        }



        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public class reportTransactionTFromMyClientFromAccountSignatory
        {
            public bool is_primary { get; set; }
            public TPersonRegistrationInReport t_person { get; set; }
            public string role { get; set; }

        }


        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public class TPersonRegistrationInReport
        {
            internal string gender;
            [XmlElement("title", typeof(XmlElement))]
            internal string title;
            [XmlElement("first_name")]
            internal string first_name;
            [XmlElement("middle_name", typeof(XmlElement))]
            internal string middle_name;
            internal string prefix;
            [XmlElement("last_name")]
            internal string last_name;
            internal Nullable<System.DateTime> birthdate;
            [XmlElement("birth_place")]
            internal string birth_place;
            [XmlElement("mothers_name")]
            internal string mothersName;
            internal string alias;
            internal string ssn;
            [XmlElement("passport_number")]
            internal string passport_number;
            [XmlElement("passport_country")]
            internal string passport_country;
            [XmlElement("id_number")]
            internal string id_number;
            internal string nationality1;
            internal string nationality2;
            internal string nationality3;
            internal string residence;
            internal Phones phones;
            internal Addresses addresses;
            [XmlElement("email", IsNullable = true)]
            internal List<string> email;
            internal string occupation;
            [XmlElement("employer_name")]
            internal string employerName;
            [XmlElement("employer_address_id")]
            internal TAddress employerAddressId;
            [XmlElement("employer_phone_id")]
            internal TPhone employerPhoneId;
            //internal List<TPersonIdentification> identification;
            internal TPersonIdentification identification;
            internal bool deceased;
            [XmlElement("date_deceased")]
            internal DateTime dateDeceased;
            [XmlElement("tax_number")]
            internal string taxNumber;
            [XmlElement("tax_reg_number")]
            internal string taxRegNumber;
            [XmlElement("source_of_wealth")]
            internal string sourceOfWealth;
            internal string comments;
            internal string source_of_wealth;
            internal string role;

            public string Gender
            {
                get { return gender; }
                set { gender = value; }
            }

            public string Title
            {
                get { return title; }
                set { title = value; }
            }

            [XmlElement("first_name")]
            public string FirstName
            {
                get { return first_name; }
                set { first_name = value; }
            }

            public string MiddleName
            {
                get { return middle_name; }
                set { middle_name = value; }
            }

            public string Prefix
            {
                get { return prefix; }
                set { prefix = value; }
            }

            [XmlElement("last_name")]
            public string LastName
            {
                get { return last_name; }
                set { last_name = value; }
            }

            public Nullable<System.DateTime> Birthdate
            {
                get { return birthdate; }
                set { birthdate = value; }
            }

            [XmlElement("birth_place")]
            public string BirthPlace
            {
                get { return birth_place; }
                set { birth_place = value; }
            }

            [XmlElement("mothers_name")]
            public string MothersName
            {
                get { return mothersName; }
                set { mothersName = value; }
            }

            public string Alias
            {
                get { return alias; }
                set { alias = value; }
            }

            public string Ssn
            {
                get { return ssn; }
                set { ssn = value; }
            }

            [XmlElement("passport_number")]
            public string PassportNumber
            {
                get { return passport_number; }
                set { passport_number = value; }
            }

            [XmlElement("passport_country")]
            public string PassportCountry
            {
                get { return passport_country; }
                set { passport_country = value; }
            }

            [XmlElement("id_number")]
            public string IdNumber
            {
                get { return id_number; }
                set { id_number = value; }
            }

            public string Nationality1
            {
                get { return nationality1; }
                set { nationality1 = value; }
            }

            public string Nationality2
            {
                get { return nationality2; }
                set { nationality2 = value; }
            }

            public string Nationality3
            {
                get { return nationality3; }
                set { nationality3 = value; }
            }

            public string Residence
            {
                get { return residence; }
                set { residence = value; }
            }


            [XmlElement("email", IsNullable = true)]
            public List<string> Email
            {
                get
                {
                    if (email == null)
                        email = new List<string>();
                    return email;
                }
            }

            public string Occupation
            {
                get { return occupation; }
                set { occupation = value; }
            }

            [XmlElement("employer_name")]
            public string EmployerName
            {
                get { return employerName; }
                set { employerName = value; }
            }

            [XmlElement("employer_address_id")]
            public TAddress EmployerAddressId
            {
                get { return employerAddressId; }
                set { employerAddressId = value; }
            }

            [XmlElement("employer_phone_id")]
            public TPhone EmployerPhoneId
            {
                get { return employerPhoneId; }
                set { employerPhoneId = value; }
            }

            //public List<TPersonIdentification> Identification
            //{
            //    get
            //    {
            //        if (identification == null)
            //            identification = new List<TPersonIdentification>();
            //        return identification;
            //    }
            //}

            public TPersonIdentification Identification
            {
                get
                {
                    if (identification == null)
                        identification = new TPersonIdentification();
                    return identification;
                }
            }

            [XmlElement("deceased")]
            public bool Deceased
            {
                get { return deceased; }
                set { deceased = value; }
            }

            [XmlElement("date_deceased")]
            public DateTime DateDeceased
            {
                get { return dateDeceased; }
                set { dateDeceased = value; }
            }

            [XmlElement("tax_number")]
            public string TaxNumber
            {
                get { return taxNumber; }
                set { taxNumber = value; }
            }

            [XmlElement("tax_reg_number")]
            public string TaxRegNumber
            {
                get { return taxRegNumber; }
                set { taxRegNumber = value; }
            }

            [XmlElement("source_of_wealth")]
            public string SourceOfWealth
            {
                get { return sourceOfWealth; }
                set { sourceOfWealth = value; }
            }

            public string Comments
            {
                get { return comments; }
                set { comments = value; }
            }

            public class Addresses
            {
                internal List<TAddress> address;

                [XmlElement("address")]
                public List<TAddress> Address
                {
                    get
                    {
                        if (address == null)
                            address = new List<TAddress>();
                        return address;
                    }
                }
            }

            //public class Addresses
            //{
            //    public TAddress address;

            //    [XmlElement("address")]
            //    public TAddress Address
            //    {
            //        get
            //        {
            //            if (address == null)
            //                address = new TAddress();
            //            return address;
            //        }
            //    }
            //}

            public class Phones
            {
                public List<TPhone> phone;

                [XmlElement("phone")]
                public List<TPhone> Phone
                {
                    get
                    {
                        if (phone == null)
                            phone = new List<TPhone>();
                        return phone;
                    }
                }
            }
        }

        //    public class Phones
        //    {
        //        public TPhone phone;

        //        [XmlElement("phone")]
        //        public TPhone Phone
        //        {
        //            get
        //            {
        //                if (phone == null)
        //                    phone = new TPhone();
        //                return phone;
        //            }
        //        }
        //    }
        //}



        [XmlType("t_person_identification")]
        public class TPersonIdentification
        {
            //[XmlElement("type")]
            //public List<IdentifierType> type { get; set; }

            [XmlElement("type")]
            public string type { get; set; }

            [XmlElement("number")]
            public string number { get; set; }

            [XmlElement("issue_date")]
            public DateTime? issue_date { get; set; }

            [XmlElement("expiry_date")]
            public DateTime? expiry_date { get; set; }

            [XmlElement("issued_by")]
            public string issued_by { get; set; }

            //[XmlElement("issue_country")]
            //public List<CountryCodes> issue_country { get; set; }

            [XmlElement("issue_country")]
            public string issue_country { get; set; }

            [XmlElement("comments")]
            public string comments { get; set; }


            public class CountryCodes
            {

                [XmlElement("value")]
                public string Value { get; set; }

                [XmlElement("description")]
                public string Description { get; set; }
            }
        }


        [XmlType("t_phone")]
        public class TPhone
        {
            [XmlElement("tph_contact_type")]
            public string tph_contact_type { get; set; }

            [XmlElement("tph_communication_type")]
            public string tph_communication_type { get; set; }

            [XmlElement("tph_country_prefix")]
            public string tph_country_prefix { get; set; }

            [XmlElement("tph_number")]
            public string tph_number { get; set; }

            [XmlElement("tph_extension")]
            public string tph_extension { get; set; }

            public string Comments { get; set; }
        }



        [XmlRoot("t_address")]
        public class TAddress
        {
            //[XmlElement("address_type")]
            //public List<AddressTypes> address_type { get; set; }

            [XmlElement("address_type")]
            public string address_type { get; set; }

            [XmlElement("address")]
            public string address { get; set; }

            [XmlElement("house_number")]
            public int house_number { get; set; }

            [XmlElement("apartment_number")]
            public int apartment_number { get; set; }

            [XmlElement("additional_address_line1")]
            public string additional_address_line1 { get; set; }

            [XmlElement("additional_address_line2")]
            public string additional_address_line2 { get; set; }

            [XmlElement("town")]
            public string town { get; set; }

            [XmlElement("city")]
            public string city { get; set; }

            [XmlElement("zip")]
            public string zip { get; set; }

            [XmlElement("country_code")]
            public string country_code { get; set; }

            [XmlElement("state")]
            public string state { get; set; }

            [XmlElement("geo_location")]
            public GeoLocations geo_location { get; set; }


            [XmlElement("comments")]
            public string Comments { get; set; }




            public class AddressTypes
            {

                [XmlElement("value")]
                public string Value { get; set; }

                [XmlElement("description")]
                public string Description { get; set; }
            }


            public class GeoLocations
            {
                [XmlElement("latitude")]
                public decimal Latitude { get; set; }

                [XmlElement("longitude")]
                public decimal Longitude { get; set; }

                [XmlElement("plus_code")]
                public string PlusCode { get; set; }

                [XmlElement("is_approx_location")]
                public bool IsApproxLocation { get; set; }

                [XmlElement("error_distance_margin")]
                public decimal ErrorDistanceMargin { get; set; }

                [XmlElement("margin_uom")]
                public decimal MarginUom { get; set; }
            }


        }


        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportLocation
        {
            internal reportLocationAddress address;

        }






        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportLocationAddress
        {
            //private byte address_typeField;

            private string address_typeField;

            private string addressField;

            private string cityField;

            private string country_codeField;

            internal string state;

            /// <remarks/>
            public string address_type
            {
                get
                {
                    return this.address_typeField;
                }
                set
                {
                    this.address_typeField = value;
                }
            }

            /// <remarks/>
            public string address
            {
                get
                {
                    return this.addressField;
                }
                set
                {
                    this.addressField = value;
                }
            }

            /// <remarks/>
            public string city
            {
                get
                {
                    return this.cityField;
                }
                set
                {
                    this.cityField = value;
                }
            }

            /// <remarks/>
            public string country_code
            {
                get
                {
                    return this.country_codeField;
                }
                set
                {
                    this.country_codeField = value;
                }
            }
        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransaction
        {

            private string transactionnumberField;

            internal string internal_ref_number;

            private string transaction_locationField;

            private string transaction_descriptionField;

            private string date_transactionField;

            internal string teller;

            internal string authorized;

            internal string late_deposit;

            internal string value_date;

            private string transmode_codeField;

            private string amount_localField;

            internal decimal? org_serial;

            internal string account_ownership;

            private reportTransactionT_from_my_client t_from_my_clientField;

            private reportTransactionT_to t_toField;

            private reportTransactionT_from t_fromField;

            private reportTransactionT_to_my_client t_to_my_clientField;
            internal string to_country;

            /// <remarks/>
            public string transactionnumber
            {
                get
                {
                    return this.transactionnumberField;
                }
                set
                {
                    this.transactionnumberField = value;
                }
            }

            /// <remarks/>
            public string transaction_location
            {
                get
                {
                    return this.transaction_locationField;
                }
                set
                {
                    this.transaction_locationField = value;
                }
            }

            /// <remarks/>
            public string transaction_description
            {
                get
                {
                    return this.transaction_descriptionField;
                }
                set
                {
                    this.transaction_descriptionField = value;
                }
            }

            /// <remarks/>
            public string date_transaction
            {
                get
                {
                    return this.date_transactionField;
                }
                set
                {
                    this.date_transactionField = value;
                }
            }

            /// <remarks/>
            public string transmode_code
            {
                get
                {
                    return this.transmode_codeField;
                }
                set
                {
                    this.transmode_codeField = value;
                }
            }

            /// <remarks/>
            public string amount_local
            {
                get
                {
                    return this.amount_localField;
                }
                set
                {
                    this.amount_localField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_from_my_client t_from_my_client
            {
                get
                {
                    return this.t_from_my_clientField;
                }
                set
                {
                    this.t_from_my_clientField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_to t_to
            {
                get
                {
                    return this.t_toField;
                }
                set
                {
                    this.t_toField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_from t_from
            {
                get
                {
                    return this.t_fromField;
                }
                set
                {
                    this.t_fromField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_to_my_client t_to_my_client
            {
                get
                {
                    return this.t_to_my_clientField;
                }
                set
                {
                    this.t_to_my_clientField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_client
        {

            private string from_funds_codeField;

            internal string from_funds_comment;

            private reportTransactionT_from_my_clientFrom_person from_personField;

            private reportTransactionT_from_my_clientFrom_entity from_entityField;

            private reportTransactionT_from_my_clientFrom_account from_accountField;

            private string from_countryField;

            /// <remarks/>
            public string from_funds_code
            {
                get
                {
                    return this.from_funds_codeField;
                }
                set
                {
                    this.from_funds_codeField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_person from_person
            {
                get
                {
                    return this.from_personField;
                }
                set
                {
                    this.from_personField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_entity from_entity
            {
                get
                {
                    return this.from_entityField;
                }
                set
                {
                    this.from_entityField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_account from_account
            {
                get
                {
                    return this.from_accountField;
                }
                set
                {
                    this.from_accountField = value;
                }
            }

            /// <remarks/>
            public string from_country
            {
                get
                {
                    return this.from_countryField;
                }
                set
                {
                    this.from_countryField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_person
        {

            private string first_nameField;

            private string last_nameField;

            private System.DateTime birthdateField;

            private string ssnField;

            private string nationality1Field;

            private string residenceField;

            private reportTransactionT_from_my_clientFrom_personPhones phonesField;

            private string occupationField;

            /// <remarks/>
            public string first_name
            {
                get
                {
                    return this.first_nameField;
                }
                set
                {
                    this.first_nameField = value;
                }
            }

            /// <remarks/>
            public string last_name
            {
                get
                {
                    return this.last_nameField;
                }
                set
                {
                    this.last_nameField = value;
                }
            }

            /// <remarks/>
            public System.DateTime birthdate
            {
                get
                {
                    return this.birthdateField;
                }
                set
                {
                    this.birthdateField = value;
                }
            }

            /// <remarks/>
            public string ssn
            {
                get
                {
                    return this.ssnField;
                }
                set
                {
                    this.ssnField = value;
                }
            }

            /// <remarks/>
            public string nationality1
            {
                get
                {
                    return this.nationality1Field;
                }
                set
                {
                    this.nationality1Field = value;
                }
            }

            /// <remarks/>
            public string residence
            {
                get
                {
                    return this.residenceField;
                }
                set
                {
                    this.residenceField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_personPhones phones
            {
                get
                {
                    return this.phonesField;
                }
                set
                {
                    this.phonesField = value;
                }
            }

            /// <remarks/>
            public string occupation
            {
                get
                {
                    return this.occupationField;
                }
                set
                {
                    this.occupationField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_personPhones
        {

            private reportTransactionT_from_my_clientFrom_personPhonesPhone phoneField;

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_personPhonesPhone phone
            {
                get
                {
                    return this.phoneField;
                }
                set
                {
                    this.phoneField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_personPhonesPhone
        {

            private string tph_contact_typeField;

            private string tph_communication_typeField;

            private string tph_country_prefixField;

            private string tph_numberField;

            /// <remarks/>
            public string tph_contact_type
            {
                get
                {
                    return this.tph_contact_typeField;
                }
                set
                {
                    this.tph_contact_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_communication_type
            {
                get
                {
                    return this.tph_communication_typeField;
                }
                set
                {
                    this.tph_communication_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_country_prefix
            {
                get
                {
                    return this.tph_country_prefixField;
                }
                set
                {
                    this.tph_country_prefixField = value;
                }
            }

            /// <remarks/>
            public string tph_number
            {
                get
                {
                    return this.tph_numberField;
                }
                set
                {
                    this.tph_numberField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_entity
        {

            private string nameField;

            private string commercial_nameField;

            private string incorporation_legal_formField;

            private string incorporation_numberField;

            //private string businessField;

            private int? businessField;

            private reportTransactionT_from_my_clientFrom_entityPhones phonesField;

            internal reportLocation addresses;

            private string incorporation_country_codeField;

            private reportTransactionT_from_my_clientFrom_entityRelated_persons related_personsField;

            internal TPersonRegistrationInReport director_id;

            private System.DateTime incorporation_dateField;

            internal string incorporation_state;

            internal string comments;

            /// <remarks/>
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            public string commercial_name
            {
                get
                {
                    return this.commercial_nameField;
                }
                set
                {
                    this.commercial_nameField = value;
                }
            }

            /// <remarks/>
            public string incorporation_legal_form
            {
                get
                {
                    return this.incorporation_legal_formField;
                }
                set
                {
                    this.incorporation_legal_formField = value;
                }
            }

            /// <remarks/>
            public string incorporation_number
            {
                get
                {
                    return this.incorporation_numberField;
                }
                set
                {
                    this.incorporation_numberField = value;
                }
            }

            /// <remarks/>
            //public string business
            //{
            //    get
            //    {
            //        return this.businessField;
            //    }
            //    set
            //    {
            //        this.businessField = value;
            //    }
            //}

            /// <remarks/>
            public int? business
            {
                get
                {
                    return this.businessField;
                }
                set
                {
                    this.businessField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_entityPhones phones
            {
                get
                {
                    return this.phonesField;
                }
                set
                {
                    this.phonesField = value;
                }
            }

            /// <remarks/>
            public string incorporation_country_code
            {
                get
                {
                    return this.incorporation_country_codeField;
                }
                set
                {
                    this.incorporation_country_codeField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_entityRelated_persons related_persons
            {
                get
                {
                    return this.related_personsField;
                }
                set
                {
                    this.related_personsField = value;
                }
            }

            /// <remarks/>
            public System.DateTime incorporation_date
            {
                get
                {
                    return this.incorporation_dateField;
                }
                set
                {
                    this.incorporation_dateField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_entityPhones
        {

            private reportTransactionT_from_my_clientFrom_entityPhonesPhone phoneField;

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_entityPhonesPhone phone
            {
                get
                {
                    return this.phoneField;
                }
                set
                {
                    this.phoneField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_entityPhonesPhone
        {

            //private byte tph_contact_typeField;

            private string tph_contact_typeField;

            private string tph_communication_typeField;

            private string tph_country_prefixField;

            private string tph_numberField;

            internal string tph_extension;

            /// <remarks/>
            public string tph_contact_type
            {
                get
                {
                    return this.tph_contact_typeField;
                }
                set
                {
                    this.tph_contact_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_communication_type
            {
                get
                {
                    return this.tph_communication_typeField;
                }
                set
                {
                    this.tph_communication_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_country_prefix
            {
                get
                {
                    return this.tph_country_prefixField;
                }
                set
                {
                    this.tph_country_prefixField = value;
                }
            }

            /// <remarks/>
            public string tph_number
            {
                get
                {
                    return this.tph_numberField;
                }
                set
                {
                    this.tph_numberField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_entityRelated_persons
        {

            private reportTransactionT_from_my_clientFrom_entityRelated_personsEntity_related_person entity_related_personField;

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_entityRelated_personsEntity_related_person entity_related_person
            {
                get
                {
                    return this.entity_related_personField;
                }
                set
                {
                    this.entity_related_personField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_entityRelated_personsEntity_related_person
        {

            private reportTransactionT_from_my_clientFrom_entityRelated_personsEntity_related_personPerson personField;

            private string roleField;

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_entityRelated_personsEntity_related_personPerson person
            {
                get
                {
                    return this.personField;
                }
                set
                {
                    this.personField = value;
                }
            }

            /// <remarks/>
            public string role
            {
                get
                {
                    return this.roleField;
                }
                set
                {
                    this.roleField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_entityRelated_personsEntity_related_personPerson
        {

            private string first_nameField;

            private string last_nameField;

            /// <remarks/>
            public string first_name
            {
                get
                {
                    return this.first_nameField;
                }
                set
                {
                    this.first_nameField = value;
                }
            }

            /// <remarks/>
            public string last_name
            {
                get
                {
                    return this.last_nameField;
                }
                set
                {
                    this.last_nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_account
        {

            private string institution_nameField;

            internal string institution_code;

            internal Boolean non_bank_institution;

            private string swiftField;

            private string branchField;

            private string accountField;

            private string currency_codeField;

            private string account_nameField;

            private string client_numberField;

            private string account_typeField;

            internal string personal_account_type;

            private reportTransactionT_from_my_clientFrom_accountRelated_persons related_personsField;

            internal reportTransactionT_from_my_clientFrom_entity t_entity;

            internal reportTransactionTFromMyClientFromAccountSignatory signatory;

            private System.DateTime? openedField;

            internal decimal? balance;

            internal System.DateTime? date_balance;

            internal string beneficiary;

            internal string comments;

            private string status_codeField;

            /// <remarks/>
            public string institution_name
            {
                get
                {
                    return this.institution_nameField;
                }
                set
                {
                    this.institution_nameField = value;
                }
            }

            /// <remarks/>
            public string swift
            {
                get
                {
                    return this.swiftField;
                }
                set
                {
                    this.swiftField = value;
                }
            }

            /// <remarks/>
            public string branch
            {
                get
                {
                    return this.branchField;
                }
                set
                {
                    this.branchField = value;
                }
            }

            /// <remarks/>
            public string account
            {
                get
                {
                    return this.accountField;
                }
                set
                {
                    this.accountField = value;
                }
            }

            /// <remarks/>
            public string currency_code
            {
                get
                {
                    return this.currency_codeField;
                }
                set
                {
                    this.currency_codeField = value;
                }
            }

            /// <remarks/>
            public string account_name
            {
                get
                {
                    return this.account_nameField;
                }
                set
                {
                    this.account_nameField = value;
                }
            }

            /// <remarks/>
            public string client_number
            {
                get
                {
                    return this.client_numberField;
                }
                set
                {
                    this.client_numberField = value;
                }
            }

            /// <remarks/>
            public string account_type
            {
                get
                {
                    return this.account_typeField;
                }
                set
                {
                    this.account_typeField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_accountRelated_persons related_persons
            {
                get
                {
                    return this.related_personsField;
                }
                set
                {
                    this.related_personsField = value;
                }
            }

            /// <remarks/>
            public System.DateTime? opened
            {
                get
                {
                    return this.openedField;
                }
                set
                {
                    this.openedField = value;
                }
            }

            /// <remarks/>
            public string status_code
            {
                get
                {
                    return this.status_codeField;
                }
                set
                {
                    this.status_codeField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_accountRelated_persons
        {

            private reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_person account_related_personField;

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_person account_related_person
            {
                get
                {
                    return this.account_related_personField;
                }
                set
                {
                    this.account_related_personField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_person
        {

            private reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_personT_person t_personField;

            private string roleField;

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_personT_person t_person
            {
                get
                {
                    return this.t_personField;
                }
                set
                {
                    this.t_personField = value;
                }
            }

            /// <remarks/>
            public string role
            {
                get
                {
                    return this.roleField;
                }
                set
                {
                    this.roleField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_personT_person
        {

            private string first_nameField;

            private string last_nameField;

            private System.DateTime birthdateField;

            private string ssnField;

            private string nationality1Field;

            private string residenceField;

            private reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_personT_personPhones phonesField;

            private string occupationField;

            /// <remarks/>
            public string first_name
            {
                get
                {
                    return this.first_nameField;
                }
                set
                {
                    this.first_nameField = value;
                }
            }

            /// <remarks/>
            public string last_name
            {
                get
                {
                    return this.last_nameField;
                }
                set
                {
                    this.last_nameField = value;
                }
            }

            /// <remarks/>
            public System.DateTime birthdate
            {
                get
                {
                    return this.birthdateField;
                }
                set
                {
                    this.birthdateField = value;
                }
            }

            /// <remarks/>
            public string ssn
            {
                get
                {
                    return this.ssnField;
                }
                set
                {
                    this.ssnField = value;
                }
            }

            /// <remarks/>
            public string nationality1
            {
                get
                {
                    return this.nationality1Field;
                }
                set
                {
                    this.nationality1Field = value;
                }
            }

            /// <remarks/>
            public string residence
            {
                get
                {
                    return this.residenceField;
                }
                set
                {
                    this.residenceField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_personT_personPhones phones
            {
                get
                {
                    return this.phonesField;
                }
                set
                {
                    this.phonesField = value;
                }
            }

            /// <remarks/>
            public string occupation
            {
                get
                {
                    return this.occupationField;
                }
                set
                {
                    this.occupationField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_personT_personPhones
        {

            private reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_personT_personPhonesPhone phoneField;

            /// <remarks/>
            public reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_personT_personPhonesPhone phone
            {
                get
                {
                    return this.phoneField;
                }
                set
                {
                    this.phoneField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from_my_clientFrom_accountRelated_personsAccount_related_personT_personPhonesPhone
        {

            private string tph_contact_typeField;

            private string tph_communication_typeField;

            private string tph_country_prefixField;

            private string tph_numberField;

            /// <remarks/>
            public string tph_contact_type
            {
                get
                {
                    return this.tph_contact_typeField;
                }
                set
                {
                    this.tph_contact_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_communication_type
            {
                get
                {
                    return this.tph_communication_typeField;
                }
                set
                {
                    this.tph_communication_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_country_prefix
            {
                get
                {
                    return this.tph_country_prefixField;
                }
                set
                {
                    this.tph_country_prefixField = value;
                }
            }

            /// <remarks/>
            public string tph_number
            {
                get
                {
                    return this.tph_numberField;
                }
                set
                {
                    this.tph_numberField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to
        {

            private string to_funds_codeField;

            internal string to_funds_comment;

            internal reportTransactionTo_foreign_currency to_foreign_currency;

            private reportTransactionT_toTo_entity to_entityField;

            private reportTransactionT_toTo_person to_personField;

            private reportTransactionT_toTo_account to_accountField;

            private string to_countryField;

            /// <remarks/>
            public string to_funds_code
            {
                get
                {
                    return this.to_funds_codeField;
                }
                set
                {
                    this.to_funds_codeField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_toTo_entity to_entity
            {
                get
                {
                    return this.to_entityField;
                }
                set
                {
                    this.to_entityField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_toTo_person to_person
            {
                get
                {
                    return this.to_personField;
                }
                set
                {
                    this.to_personField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_toTo_account to_account
            {
                get
                {
                    return this.to_accountField;
                }
                set
                {
                    this.to_accountField = value;
                }
            }

            /// <remarks/>
            public string to_country
            {
                get
                {
                    return this.to_countryField;
                }
                set
                {
                    this.to_countryField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_toTo_entity
        {

            private string nameField;

            /// <remarks/>
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_toTo_person
        {

            private string first_nameField;

            private string last_nameField;

            /// <remarks/>
            public string first_name
            {
                get
                {
                    return this.first_nameField;
                }
                set
                {
                    this.first_nameField = value;
                }
            }

            /// <remarks/>
            public string last_name
            {
                get
                {
                    return this.last_nameField;
                }
                set
                {
                    this.last_nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_toTo_account
        {

            private string institution_nameField;

            internal string institution_code;

            internal Boolean non_bank_institution;

            private string swiftField;

            private string accountField;

            internal string account_name;

            /// <remarks/>
            public string institution_name
            {
                get
                {
                    return this.institution_nameField;
                }
                set
                {
                    this.institution_nameField = value;
                }
            }

            /// <remarks/>
            public string swift
            {
                get
                {
                    return this.swiftField;
                }
                set
                {
                    this.swiftField = value;
                }
            }

            /// <remarks/>
            public string account
            {
                get
                {
                    return this.accountField;
                }
                set
                {
                    this.accountField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_from
        {

            private string from_funds_codeField;

            internal string from_funds_comment;

            private reportTransactionT_fromFrom_entity from_entityField;

            private reportTransactionT_fromFrom_person from_personField;

            private reportTransactionT_fromFrom_account from_accountField;

            private string from_countryField;

            /// <remarks/>
            public string from_funds_code
            {
                get
                {
                    return this.from_funds_codeField;
                }
                set
                {
                    this.from_funds_codeField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_fromFrom_entity from_entity
            {
                get
                {
                    return this.from_entityField;
                }
                set
                {
                    this.from_entityField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_fromFrom_person from_person
            {
                get
                {
                    return this.from_personField;
                }
                set
                {
                    this.from_personField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_fromFrom_account from_account
            {
                get
                {
                    return this.from_accountField;
                }
                set
                {
                    this.from_accountField = value;
                }
            }

            /// <remarks/>
            public string from_country
            {
                get
                {
                    return this.from_countryField;
                }
                set
                {
                    this.from_countryField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_fromFrom_entity
        {

            private string nameField;

            /// <remarks/>
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_fromFrom_person
        {

            private string first_nameField;

            private string last_nameField;

            /// <remarks/>
            public string first_name
            {
                get
                {
                    return this.first_nameField;
                }
                set
                {
                    this.first_nameField = value;
                }
            }

            /// <remarks/>
            public string last_name
            {
                get
                {
                    return this.last_nameField;
                }
                set
                {
                    this.last_nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_fromFrom_account
        {

            private string institution_nameField;

            internal string institution_code;

            internal Boolean non_bank_institution;

            private string swiftField;

            private string accountField;

            internal string account_name;

            /// <remarks/>
            public string institution_name
            {
                get
                {
                    return this.institution_nameField;
                }
                set
                {
                    this.institution_nameField = value;
                }
            }

            /// <remarks/>
            public string swift
            {
                get
                {
                    return this.swiftField;
                }
                set
                {
                    this.swiftField = value;
                }
            }

            /// <remarks/>
            public string account
            {
                get
                {
                    return this.accountField;
                }
                set
                {
                    this.accountField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_client
        {

            private string to_funds_codeField;

            internal string to_funds_comment;

            internal reportTransactionTo_foreign_currency to_foreign_currency;

            private reportTransactionT_to_my_clientTo_person to_personField;

            private reportTransactionT_to_my_clientTo_entity to_entityField;

            private reportTransactionT_to_my_clientTo_account to_accountField;

            //internal string to_country;

            internal string to_country;

            /// <remarks/>
            public string to_funds_code
            {
                get
                {
                    return this.to_funds_codeField;
                }
                set
                {
                    this.to_funds_codeField = value;
                }
            }



            /// <remarks/>
            public reportTransactionT_to_my_clientTo_person to_person
            {
                get
                {
                    return this.to_personField;
                }
                set
                {
                    this.to_personField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_entity to_entity
            {
                get
                {
                    return this.to_entityField;
                }
                set
                {
                    this.to_entityField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_account to_account
            {
                get
                {
                    return this.to_accountField;
                }
                set
                {
                    this.to_accountField = value;
                }
            }

            /// <remarks/>
            //public string to_countryField
            //{
            //    get
            //    {
            //        return this.to_country;
            //    }
            //    set
            //    {
            //        this.to_country = value;
            //    }
            //}
        }



        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public class reportTransactionTo_foreign_currency

        {
            internal string foreign_currency_code;

            internal decimal? foreign_amount;

            internal decimal? foreign_exchange_rate;

        }
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_person
        {

            private string first_nameField;

            private string last_nameField;

            private System.DateTime birthdateField;

            private string ssnField;

            private string nationality1Field;

            private string residenceField;

            private reportTransactionT_to_my_clientTo_personPhones phonesField;

            private string occupationField;

            /// <remarks/>
            public string first_name
            {
                get
                {
                    return this.first_nameField;
                }
                set
                {
                    this.first_nameField = value;
                }
            }

            /// <remarks/>
            public string last_name
            {
                get
                {
                    return this.last_nameField;
                }
                set
                {
                    this.last_nameField = value;
                }
            }

            /// <remarks/>
            public System.DateTime birthdate
            {
                get
                {
                    return this.birthdateField;
                }
                set
                {
                    this.birthdateField = value;
                }
            }

            /// <remarks/>
            public string ssn
            {
                get
                {
                    return this.ssnField;
                }
                set
                {
                    this.ssnField = value;
                }
            }

            /// <remarks/>
            public string nationality1
            {
                get
                {
                    return this.nationality1Field;
                }
                set
                {
                    this.nationality1Field = value;
                }
            }

            /// <remarks/>
            public string residence
            {
                get
                {
                    return this.residenceField;
                }
                set
                {
                    this.residenceField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_personPhones phones
            {
                get
                {
                    return this.phonesField;
                }
                set
                {
                    this.phonesField = value;
                }
            }

            /// <remarks/>
            public string occupation
            {
                get
                {
                    return this.occupationField;
                }
                set
                {
                    this.occupationField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_personPhones
        {

            private reportTransactionT_to_my_clientTo_personPhonesPhone phoneField;

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_personPhonesPhone phone
            {
                get
                {
                    return this.phoneField;
                }
                set
                {
                    this.phoneField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_personPhonesPhone
        {

            private string tph_contact_typeField;

            private string tph_communication_typeField;

            private string tph_country_prefixField;

            private string tph_numberField;

            internal string tph_extension;

            /// <remarks/>
            public string tph_contact_type
            {
                get
                {
                    return this.tph_contact_typeField;
                }
                set
                {
                    this.tph_contact_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_communication_type
            {
                get
                {
                    return this.tph_communication_typeField;
                }
                set
                {
                    this.tph_communication_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_country_prefix
            {
                get
                {
                    return this.tph_country_prefixField;
                }
                set
                {
                    this.tph_country_prefixField = value;
                }
            }

            /// <remarks/>
            public string tph_number
            {
                get
                {
                    return this.tph_numberField;
                }
                set
                {
                    this.tph_numberField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_entity
        {

            private string nameField;

            private string commercial_nameField;

            private string incorporation_legal_formField;

            private string incorporation_numberField;

            private int? businessField;

            private reportTransactionT_to_my_clientTo_entityPhones phonesField;

            private string incorporation_country_codeField;

            internal string incorporation_state;

            private reportTransactionT_to_my_clientTo_entityRelated_persons related_personsField;

            internal reportLocation addresses;

            internal TPersonRegistrationInReport director_id;

            private System.DateTime incorporation_dateField;

            internal string comments;

            /// <remarks/>
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            public string commercial_name
            {
                get
                {
                    return this.commercial_nameField;
                }
                set
                {
                    this.commercial_nameField = value;
                }
            }

            /// <remarks/>
            public string incorporation_legal_form
            {
                get
                {
                    return this.incorporation_legal_formField;
                }
                set
                {
                    this.incorporation_legal_formField = value;
                }
            }

            /// <remarks/>
            public string incorporation_number
            {
                get
                {
                    return this.incorporation_numberField;
                }
                set
                {
                    this.incorporation_numberField = value;
                }
            }

            /// <remarks/>
            public int? business
            {
                get
                {
                    return this.businessField;
                }
                set
                {
                    this.businessField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_entityPhones phones
            {
                get
                {
                    return this.phonesField;
                }
                set
                {
                    this.phonesField = value;
                }
            }

            /// <remarks/>
            public string incorporation_country_code
            {
                get
                {
                    return this.incorporation_country_codeField;
                }
                set
                {
                    this.incorporation_country_codeField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_entityRelated_persons related_persons
            {
                get
                {
                    return this.related_personsField;
                }
                set
                {
                    this.related_personsField = value;
                }
            }

            /// <remarks/>
            public System.DateTime incorporation_date
            {
                get
                {
                    return this.incorporation_dateField;
                }
                set
                {
                    this.incorporation_dateField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_entityPhones
        {

            private reportTransactionT_to_my_clientTo_entityPhonesPhone phoneField;

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_entityPhonesPhone phone
            {
                get
                {
                    return this.phoneField;
                }
                set
                {
                    this.phoneField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_entityPhonesPhone
        {

            private string tph_contact_typeField;

            private string tph_communication_typeField;

            private string tph_country_prefixField;

            private string tph_numberField;

            internal string tph_extension;

            /// <remarks/>
            public string tph_contact_type
            {
                get
                {
                    return this.tph_contact_typeField;
                }
                set
                {
                    this.tph_contact_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_communication_type
            {
                get
                {
                    return this.tph_communication_typeField;
                }
                set
                {
                    this.tph_communication_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_country_prefix
            {
                get
                {
                    return this.tph_country_prefixField;
                }
                set
                {
                    this.tph_country_prefixField = value;
                }
            }

            /// <remarks/>
            public string tph_number
            {
                get
                {
                    return this.tph_numberField;
                }
                set
                {
                    this.tph_numberField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_entityRelated_persons
        {

            private reportTransactionT_to_my_clientTo_entityRelated_personsEntity_related_person entity_related_personField;

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_entityRelated_personsEntity_related_person entity_related_person
            {
                get
                {
                    return this.entity_related_personField;
                }
                set
                {
                    this.entity_related_personField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_entityRelated_personsEntity_related_person
        {

            private reportTransactionT_to_my_clientTo_entityRelated_personsEntity_related_personPerson personField;

            private string roleField;

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_entityRelated_personsEntity_related_personPerson person
            {
                get
                {
                    return this.personField;
                }
                set
                {
                    this.personField = value;
                }
            }

            /// <remarks/>
            public string role
            {
                get
                {
                    return this.roleField;
                }
                set
                {
                    this.roleField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_entityRelated_personsEntity_related_personPerson
        {

            private string first_nameField;

            private string last_nameField;

            /// <remarks/>
            public string first_name
            {
                get
                {
                    return this.first_nameField;
                }
                set
                {
                    this.first_nameField = value;
                }
            }

            /// <remarks/>
            public string last_name
            {
                get
                {
                    return this.last_nameField;
                }
                set
                {
                    this.last_nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_account
        {

            private string institution_nameField;

            internal string institution_code;

            internal Boolean non_bank_institution;

            private string swiftField;

            private string branchField;

            private string accountField;

            private string currency_codeField;

            private string account_nameField;

            private string client_numberField;

            internal string personal_account_type;

            //internal List<reportTransactionTFromMyClientFromAccountSignatory> signatory;

            internal reportTransactionTFromMyClientFromAccountSignatory signatory;

            internal reportTransactionT_to_my_clientTo_entity t_entity;

            private string account_typeField;

            private reportTransactionT_to_my_clientTo_accountRelated_persons related_personsField;

            private System.DateTime? openedField;

            internal decimal? balance;

            internal System.DateTime? date_balance;

            internal string beneficiary;

            internal string comments;

            private string status_codeField;

            /// <remarks/>
            public string institution_name
            {
                get
                {
                    return this.institution_nameField;
                }
                set
                {
                    this.institution_nameField = value;
                }
            }

            /// <remarks/>
            public string swift
            {
                get
                {
                    return this.swiftField;
                }
                set
                {
                    this.swiftField = value;
                }
            }

            /// <remarks/>
            public string branch
            {
                get
                {
                    return this.branchField;
                }
                set
                {
                    this.branchField = value;
                }
            }

            /// <remarks/>
            public string account
            {
                get
                {
                    return this.accountField;
                }
                set
                {
                    this.accountField = value;
                }
            }

            /// <remarks/>
            public string currency_code
            {
                get
                {
                    return this.currency_codeField;
                }
                set
                {
                    this.currency_codeField = value;
                }
            }

            /// <remarks/>
            public string account_name
            {
                get
                {
                    return this.account_nameField;
                }
                set
                {
                    this.account_nameField = value;
                }
            }

            /// <remarks/>
            public string client_number
            {
                get
                {
                    return this.client_numberField;
                }
                set
                {
                    this.client_numberField = value;
                }
            }

            /// <remarks/>
            public string account_type
            {
                get
                {
                    return this.account_typeField;
                }
                set
                {
                    this.account_typeField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_accountRelated_persons related_persons
            {
                get
                {
                    return this.related_personsField;
                }
                set
                {
                    this.related_personsField = value;
                }
            }

            /// <remarks/>
            public System.DateTime? opened
            {
                get
                {
                    return this.openedField;
                }
                set
                {
                    this.openedField = value;
                }
            }

            /// <remarks/>
            public string status_code
            {
                get
                {
                    return this.status_codeField;
                }
                set
                {
                    this.status_codeField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_accountRelated_persons
        {

            private reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_person account_related_personField;

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_person account_related_person
            {
                get
                {
                    return this.account_related_personField;
                }
                set
                {
                    this.account_related_personField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_person
        {

            private reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_person t_personField;

            private string roleField;

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_person t_person
            {
                get
                {
                    return this.t_personField;
                }
                set
                {
                    this.t_personField = value;
                }
            }

            /// <remarks/>
            public string role
            {
                get
                {
                    return this.roleField;
                }
                set
                {
                    this.roleField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_person
        {

            private string first_nameField;

            private string last_nameField;

            private System.DateTime birthdateField;

            private string ssnField;

            private string nationality1Field;

            private string residenceField;

            private reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_personPhones phonesField;

            private string occupationField;

            /// <remarks/>
            public string first_name
            {
                get
                {
                    return this.first_nameField;
                }
                set
                {
                    this.first_nameField = value;
                }
            }

            /// <remarks/>
            public string last_name
            {
                get
                {
                    return this.last_nameField;
                }
                set
                {
                    this.last_nameField = value;
                }
            }

            /// <remarks/>
            public System.DateTime birthdate
            {
                get
                {
                    return this.birthdateField;
                }
                set
                {
                    this.birthdateField = value;
                }
            }

            /// <remarks/>
            public string ssn
            {
                get
                {
                    return this.ssnField;
                }
                set
                {
                    this.ssnField = value;
                }
            }

            /// <remarks/>
            public string nationality1
            {
                get
                {
                    return this.nationality1Field;
                }
                set
                {
                    this.nationality1Field = value;
                }
            }

            /// <remarks/>
            public string residence
            {
                get
                {
                    return this.residenceField;
                }
                set
                {
                    this.residenceField = value;
                }
            }

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_personPhones phones
            {
                get
                {
                    return this.phonesField;
                }
                set
                {
                    this.phonesField = value;
                }
            }

            /// <remarks/>
            public string occupation
            {
                get
                {
                    return this.occupationField;
                }
                set
                {
                    this.occupationField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_personPhones
        {

            private reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_personPhonesPhone phoneField;

            /// <remarks/>
            public reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_personPhonesPhone phone
            {
                get
                {
                    return this.phoneField;
                }
                set
                {
                    this.phoneField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_personPhonesPhone
        {

            private string tph_contact_typeField;

            private string tph_communication_typeField;

            private string tph_country_prefixField;

            private string tph_numberField;

            /// <remarks/>
            public string tph_contact_type
            {
                get
                {
                    return this.tph_contact_typeField;
                }
                set
                {
                    this.tph_contact_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_communication_type
            {
                get
                {
                    return this.tph_communication_typeField;
                }
                set
                {
                    this.tph_communication_typeField = value;
                }
            }

            /// <remarks/>
            public string tph_country_prefix
            {
                get
                {
                    return this.tph_country_prefixField;
                }
                set
                {
                    this.tph_country_prefixField = value;
                }
            }

            /// <remarks/>
            public string tph_number
            {
                get
                {
                    return this.tph_numberField;
                }
                set
                {
                    this.tph_numberField = value;
                }
            }
        }



    }
}