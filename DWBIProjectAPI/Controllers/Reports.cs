using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public partial class reportLocation
        {

            private byte address_typeField;

            private string addressField;

            private string cityField;

            private string country_codeField;

            /// <remarks/>
            public byte address_type
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

            private string transaction_locationField;

            private string transaction_descriptionField;

            private string date_transactionField;

            private string transmode_codeField;

            private string amount_localField;

            private reportTransactionT_from_my_client t_from_my_clientField;

            private reportTransactionT_to t_toField;

            private reportTransactionT_from t_fromField;

            private reportTransactionT_to_my_client t_to_my_clientField;

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

            private string businessField;

            private reportTransactionT_from_my_clientFrom_entityPhones phonesField;

            private string incorporation_country_codeField;

            private reportTransactionT_from_my_clientFrom_entityRelated_persons related_personsField;

            private System.DateTime incorporation_dateField;

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
            public string business
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

            private byte tph_contact_typeField;

            private string tph_communication_typeField;

            private string tph_country_prefixField;

            private string tph_numberField;

            /// <remarks/>
            public byte tph_contact_type
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

            private string swiftField;

            private string branchField;

            private string accountField;

            private string currency_codeField;

            private string account_nameField;

            private string client_numberField;

            private string account_typeField;

            private reportTransactionT_from_my_clientFrom_accountRelated_persons related_personsField;

            private System.DateTime openedField;

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
            public System.DateTime opened
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

            private string swiftField;

            private string accountField;

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

            private string swiftField;

            private string accountField;

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

            private reportTransactionT_to_my_clientTo_person to_personField;

            private reportTransactionT_to_my_clientTo_entity to_entityField;

            private reportTransactionT_to_my_clientTo_account to_accountField;

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

            private string businessField;

            private reportTransactionT_to_my_clientTo_entityPhones phonesField;

            private string incorporation_country_codeField;

            private reportTransactionT_to_my_clientTo_entityRelated_persons related_personsField;

            private System.DateTime incorporation_dateField;

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
            public string business
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

            private byte tph_contact_typeField;

            private string tph_communication_typeField;

            private string tph_country_prefixField;

            private string tph_numberField;

            /// <remarks/>
            public byte tph_contact_type
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

            private string swiftField;

            private string branchField;

            private string accountField;

            private string currency_codeField;

            private string account_nameField;

            private string client_numberField;

            private string account_typeField;

            private reportTransactionT_to_my_clientTo_accountRelated_persons related_personsField;

            private System.DateTime openedField;

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
            public System.DateTime opened
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