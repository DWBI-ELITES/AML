using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Web.Http.Cors;
using DWBIProjectAPI.Models;
using Newtonsoft.Json.Linq;
using System.Globalization;


using System.Xml;
using static DWBIProjectAPI.Controllers.Reports;
using System.Data.Entity;
using static DWBIProjectAPI.Controllers.Reports.TPersonRegistrationInReport;

namespace DWBIProjectAPI.Controllers
{
    public class ReportsController : ApiController


    {

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetPerson")]


       


        public List<TPersonModel> GetPerson(string custId)
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<TPersonModel> tPersonList = new List<TPersonModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "Select * FROM [AMLData].[dbo].[amlPerson] where cust_id = @custId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@custId", custId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TPersonModel tPerson = new TPersonModel
                        {
                            PERSONID = reader["PERSONID"].ToString(),
                            birth_place = reader["birth_place"].ToString(),
                            birthdate = reader["birthdate"] as DateTime?,
                            cust_id = reader["cust_id"].ToString(),
                            deceased = reader["deceased"] as bool?,
                            deceased_date = reader["deceased_date"] as DateTime?,
                            email = reader["email"].ToString(),
                            employer_name = reader["employer_name"].ToString(),
                            first_name = reader["first_name"].ToString(),
                            foreigner = reader["foreigner"] as bool?,
                            identifier_code = reader["identifier_code"].ToString(),
                            identifier_country = reader["identifier_country"].ToString(),
                            identifier_expire_date = reader["identifier_expire_date"] as DateTime?,
                            identifier_issue_date = reader["identifier_issue_date"] as DateTime?,
                            identifier_issuer = reader["identifier_issuer"].ToString(),
                            identifier_number = reader["identifier_number"].ToString(),
                            identifier_other = reader["identifier_other"].ToString(),
                            identifier_state = reader["identifier_state"].ToString(),
                            issuer_id = reader["issuer_id"].ToString(),
                            last_name = reader["last_name"].ToString(),
                            lga_of_origin = reader["lga_of_origin"].ToString(),
                            middle_name = reader["middle_name"].ToString(),
                            mothers_name = reader["mothers_name"].ToString(),
                            nationality = reader["nationality"].ToString(),
                            nok_address1 = reader["nok_address1"].ToString(),
                            nok_address2 = reader["nok_address2"].ToString(),
                            nok_email = reader["nok_email"].ToString(),
                            nok_name = reader["nok_name"].ToString(),
                            nok_phone = reader["nok_phone"].ToString(),
                            nok_relationship = reader["nok_relationship"].ToString(),
                            occupation = reader["occupation"].ToString(),
                            p_add_address1 = reader["p_add_address1"].ToString(),
                            p_add_address2 = reader["p_add_address2"].ToString(),
                            p_add_city = reader["p_add_city"].ToString(),
                            p_add_country_code = reader["p_add_country_code"].ToString(),
                            p_add_state = reader["p_add_state"].ToString(),
                            p_add_zip = reader["p_add_zip"].ToString(),
                            p_alias = reader["p_alias"].ToString(),
                            passport_number = reader["passport_number"].ToString(),
                            passport_issue_country = reader["passport_issue_country"].ToString(),
                            prefix_name = reader["prefix_name"].ToString(),
                            RECORD_STATUS = reader["RECORD_STATUS"].ToString(),
                            referee_person_id = reader["referee_person_id"].ToString(),
                            reference_code = reader["reference_code"].ToString(),
                            residence = reader["residence"].ToString(),
                            sex = reader["sex"].ToString(),
                            source_of_weqlth = reader["source_of_weqlth"].ToString(),
                            ssn = reader["ssn"].ToString(),
                            foreigner_date_arrival = reader["foreigner_date_arrival"] as DateTime?,
                            foreigner_nationality = reader["foreigner_nationality"].ToString(),
                            foreigner_passport_exp_dt = reader["foreigner_passport_exp_dt"] as DateTime?,
                            foreigner_passport_iss_dt = reader["foreigner_passport_iss_dt"] as DateTime?,
                            foreigner_passport_number = reader["foreigner_passport_number"].ToString(),
                            foreigner_permit_number = reader["foreigner_permit_number"].ToString(),
                            foreigner_permit_valid_from = reader["foreigner_permit_valid_from"] as DateTime?,
                            foreigner_permit_valid_to = reader["foreigner_permit_valid_to"] as DateTime?,
                            foreigner_visa_number = reader["foreigner_visa_number"].ToString(),
                            tax_comments = reader["tax_comments"].ToString(),
                            tax_number = reader["tax_number"].ToString(),
                            tax_reg_number = reader["tax_reg_number"].ToString(),
                            title = reader["title"].ToString(),
                            update_date = reader["update_date"] as DateTime?,
                            updated_by = reader["updated_by"].ToString(),
                            address_id = reader["address_id"].ToString(),
                            phone_id = reader["phone_id"].ToString(),
                            addressType = reader["addressType"].ToString(),
                            address1 = reader["address1"].ToString(),
                            address2 = reader["address2"].ToString(),
                            town = reader["town"].ToString(),
                            city = reader["city"].ToString(),
                            zip = reader["zip"].ToString(),
                            country_code = reader["country_code"].ToString(),
                            state = reader["state"].ToString(),
                            tph_contact_type = reader["tph_contact_type"].ToString(),
                            tph_country_prefix = reader["tph_country_prefix"].ToString(),
                            tph_number = reader["tph_number"].ToString(),
                            tph_extension = reader["tph_extension"].ToString(),
                            tph_fax = reader["tph_fax"].ToString(),
                            TPH_COMMUNICATION_TYPE = reader["TPH_COMMUNICATION_TYPE"].ToString()
                        };

                        tPersonList.Add(tPerson);
                    }
                }
            }

            if (tPersonList.Count > 0)
            {
                return tPersonList; // Return the first person in the list
            }

            return null; // Return null if no person details found for the specified personId
        }



        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/Reports/GetTransactions")]
        public IHttpActionResult GetTransactions(string startDate, string endDate)
        {
            List<reportTransaction> transactionDetailsList = RetrieveTransactionsFromDatabase(startDate, endDate);

            if (transactionDetailsList.Count > 0)
            {
                XmlDocument ctrXmlDoc = GenerateCTRAMLReport(transactionDetailsList);
                ctrXmlDoc.Save("C:\\Users\\Adegboyega.Oluwagbem\\Downloads\\CTR_REPORT.xml");

                return Ok(ctrXmlDoc.OuterXml);
            }

            return NotFound();
        }

        private List<reportTransaction> RetrieveTransactionsFromDatabase(string startDate, string endDate)
        {
            List<reportTransaction> transactionDetailsList = new List<reportTransaction>();

            using (var context = new Entities())
            {
                DateTime startDateTime = DateTime.Parse(startDate);
                DateTime endDateTime = DateTime.Parse(endDate);

                var transactions = context.txn_live
                    .Where(t => t.TRAN_DATE >= startDateTime && t.TRAN_DATE <= endDateTime)
                    .ToList(); // Load transactions into memory

                foreach (var transaction in transactions)
                {
                    var custNumber = transaction?.CUSTOMER;
                    var personID = transaction?.PERSON_ID;
                    var tranCURRENCY = transaction?.TRAN_CURRENCY;
                    

                    //var accountDetails = context.amlAccounts.SingleOrDefault(a => a.cust_number == custNumber);
                    var accountNumber = transaction?.ACCOUNT;
                    var accountDetails = context.amlAccounts.SingleOrDefault(a => a.account == accountNumber);
                    var branchId = transaction?.BRANCH_ID;
                    var branchDetails = context.amlbranches.SingleOrDefault(b => b.branch_id == branchId);

                    var customerDetails = context.amlCustomers.Where(f => f.cust_id == custNumber).ToList();
                    var customer = customerDetails.FirstOrDefault();


                    var addressDetails = context.amlAddresses.Where(c => c.address_id == custNumber).ToList();
                    var address = addressDetails.FirstOrDefault();

                    var personList = context.amlPersons.Where(p => p.cust_id == custNumber).ToList();
                    var person = personList.FirstOrDefault();

                    var directorList = context.amlDirectors.Where(d => d.person_id == personID).ToList();
                    var directorData = directorList.FirstOrDefault();

                    var amlConfiguration = context.aml_configuration.ToList();
                    var amlConfigurationData = amlConfiguration.FirstOrDefault();

                    var signatoryList = context.amlSignatories.Where(g => g.account == accountNumber).ToList();
                    var signatoryData = signatoryList.FirstOrDefault();

                    var foreignCurrencyList = context.foreign_currency.Where(l => l.foreign_currency_code == tranCURRENCY).ToList();
                    var foreignCurrencyData = foreignCurrencyList.FirstOrDefault();



                    reportTransaction transactionDetails = new reportTransaction
                    {
                        transactionnumber = transaction?.TRAN_ID.ToString(),
                        internal_ref_number = " ",
                        transaction_location = branchDetails?.name,
                        transaction_description = transaction?.TRAN_PARTICULAR,
                        date_transaction = transaction?.TRAN_DATE.ToString(),
                        value_date = transaction?.VALUE_DATE.ToString(),
                        transmode_code = transaction?.TRAN_TYPE,
                        amount_local = transaction?.AMOUNT.ToString(),

                        t_from_my_client = new reportTransactionT_from_my_client
                        {
                            from_funds_code = transaction?.DRCR_IND,
                            from_funds_comment = "", // You may need to populate this based on your data

                            from_account = new reportTransactionT_from_my_clientFrom_account
                            {
                                institution_name = amlConfigurationData?.institution_name,
                                institution_code = amlConfigurationData?.institution_code,
                                non_bank_institution = false, // You may need to get this from your data
                                branch = accountDetails?.branch,
                                account = transaction?.ACCOUNT,
                                currency_code = transaction?.TRAN_CURRENCY,
                                account_name = accountDetails?.name,
                                client_number = accountDetails.cust_number,
                                personal_account_type = accountDetails?.account_type, // You may need to get this from your data

                                t_entity = new reportTransactionT_from_my_clientFrom_entity
                                {
                                    name = customer?.name,
                                    commercial_name = customer?.commercial_name,
                                    incorporation_legal_form = " ", // You may need to get this from your data
                                    incorporation_number = customer?.incorporation_number, // You may need to get this from your data
                                    business = customer?.business, // You may need to get this from your data

                                    phones = new reportTransactionT_from_my_clientFrom_entityPhones
                                    {
                                        phone = new reportTransactionT_from_my_clientFrom_entityPhonesPhone
                                        {
                                            tph_contact_type = person?.tph_contact_type, // You may need to get this from your data
                                            tph_communication_type = person?.TPH_COMMUNICATION_TYPE, // You may need to get this from your data
                                            tph_country_prefix = person?.tph_country_prefix,
                                            tph_number = person?.tph_number, // You may need to get this from your data
                                            tph_extension = person?.tph_extension // You may need to get this from your data
                                        }
                                    },

                                    addresses = new reportLocation
                                    {
                                        address = new reportLocationAddress
                                        {
                                            address_type = address?.addresstype, // You may need to get this from your data
                                            address = address?.address1, // You may need to get this from your data
                                            city = address?.city, // You may need to get this from your data
                                            country_code = address?.country_code, // You may need to get this from your data
                                            state = address?.state // You may need to get this from your data
                                        }
                                    },

                                    incorporation_state = customer?.incorporation_state, // You may need to get this from your data
                                    incorporation_country_code = customer?.incorporation_country_code, // You may need to get this from your data

                                    /*director_id = GetDirectorDataFromDatabase(transaction.ID), */// Replace with your actual method to get director data

                                    director_id = new TPersonRegistrationInReport
                                    {
                                        gender = person?.sex,
                                        title = person?.title,
                                        first_name = person?.first_name,
                                        last_name = person?.last_name,
                                        birthdate = person?.birthdate,
                                        nationality1 = person?.nationality,
                                        residence = person?.residence,

                                        phones = new TPersonRegistrationInReport.Phones
                                        {
                                            phone = new List<TPhone>
                                        {
                                              new TPhone
                                              {
                                                tph_contact_type = person?.tph_contact_type, // You may need to get this from your data
                                                tph_communication_type = person?.TPH_COMMUNICATION_TYPE, // You may need to get this from your data
                                                tph_country_prefix = person?.tph_country_prefix,
                                                tph_number = person?.tph_number, // You may need to get this from your data
                                                tph_extension = person?.tph_extension // You may need to get this from your data
                                              }
                                            }
                                        },

                                        addresses = new TPersonRegistrationInReport.Addresses
                                        {
                                            address = new List<TAddress>
                                              {
                                                new TAddress
                                                {
                                                address_type = address?.addresstype, // You may need to get this from your data
                                                address = address?.address1, // You may need to get this from your data
                                                city = address?.city, // You may need to get this from your data
                                                country_code = address?.country_code, // You may need to get this from your data
                                                state = address?.state // You may need to get this from your data
                                            }
                                        }
                                        },

                                        occupation = person?.occupation,

                                        identification = new TPersonIdentification
                                        {

                                            type = person?.identifier_code,
                                            number = person?.identifier_number,
                                            issue_date = person?.identifier_issue_date,
                                            expiry_date = person?.identifier_expire_date,
                                            issued_by = person?.identifier_issuer,
                                            issue_country = person?.identifier_country,


                                        },

                                        source_of_wealth = person?.source_of_weqlth,
                                        role = directorData?.role
                                    },

                                    incorporation_date = DateTime.Parse("1999-12-21T00:00:00"), // You may need to get this from your data
                                    comments = transaction?.TRAN_COMMENTS // You may need to populate this based on your data
                                },



                                signatory = new reportTransactionTFromMyClientFromAccountSignatory
                                {
                                    is_primary = true,
                                    t_person = new TPersonRegistrationInReport
                                    {
                                        gender = person?.sex,
                                        title = person?.title,
                                        first_name = person?.first_name,
                                        middle_name = person?.middle_name,
                                        last_name = person?.last_name,
                                        birthdate = person?.birthdate,
                                        birth_place = person?.birth_place,
                                        passport_number = person?.passport_number,
                                        passport_country = person?.passport_issue_country,
                                        id_number = person?.identifier_number,
                                        nationality1 = person?.nationality,
                                        residence = person?.residence,

                                        phones = new TPersonRegistrationInReport.Phones
                                        {
                                            phone = new List<TPhone>
                                        {
                                              new TPhone
                                              {
                                                tph_contact_type = person?.tph_contact_type, // You may need to get this from your data
                                                tph_communication_type = person?.TPH_COMMUNICATION_TYPE, // You may need to get this from your data
                                                tph_country_prefix = person?.tph_country_prefix,
                                                tph_number = person?.tph_number, // You may need to get this from your data
                                                tph_extension = person?.tph_extension // You may need to get this from your data
                                            }
                                            }
                                        },

                                        addresses = new TPersonRegistrationInReport.Addresses
                                        {
                                            address = new List<TAddress>
                                              {
                                                new TAddress
                                                {
                                                address_type = address?.addresstype, // You may need to get this from your data
                                                address = address?.address1, // You may need to get this from your data
                                                city = address?.city, // You may need to get this from your data
                                                country_code = address?.country_code, // You may need to get this from your data
                                                state = address?.state // You may need to get this from your data
                                            }

                                            }
                                        },

                                        occupation = person?.occupation,

                                        identification = new TPersonIdentification
                                        {
                                            type = person?.identifier_code,
                                            number = person?.identifier_number,
                                            issue_date = person?.identifier_issue_date,
                                            expiry_date = person?.identifier_expire_date,
                                            issued_by = person?.identifier_issuer,
                                            issue_country = person?.identifier_country,


                                        },
                                        source_of_wealth = person?.source_of_weqlth,
                                        comments = transaction?.TRAN_COMMENTS,
                                    },
                                    role = signatoryData.role
                                },
                                    opened = accountDetails.opened,
                                    balance = transaction.ACCT_BAL,
                                    date_balance = transaction.ACCT_BAL_DATE,
                                    status_code = transaction.ACCOUNT_STATUS,
                                    beneficiary = transaction.ADDRESS_OF_BENEFICIARY,
                                    comments =  transaction.TRAN_COMMENTS
                },

                            from_country = transaction?.TXN_COUNTRY // You may need to get this from your data
                        },


                        t_to_my_client = new reportTransactionT_to_my_client
                        {
                            to_funds_code = transaction?.DRCR_IND,
                            to_funds_comment = " ",
                            to_foreign_currency = new reportTransactionTo_foreign_currency
                            {
                                foreign_currency_code = foreignCurrencyData?.foreign_currency_code,
                                foreign_amount = foreignCurrencyData?.foreign_amount,
                                foreign_exchange_rate = foreignCurrencyData?.foreign_exchange_rate,
                            },
                            to_account = new reportTransactionT_to_my_clientTo_account
                            {
                                institution_name = amlConfigurationData?.institution_name,
                                institution_code = amlConfigurationData?.institution_code,
                                non_bank_institution = false, // You may need to get this from your data
                                branch = accountDetails?.branch,
                                account = transaction?.ACCOUNT,
                                currency_code = transaction?.TRAN_CURRENCY,
                                account_name = accountDetails?.name,
                                client_number = accountDetails.cust_number,
                                personal_account_type = accountDetails?.account_type, // You may need to get this from your data

                                t_entity = new reportTransactionT_to_my_clientTo_entity
                                {
                                    name = customer?.name,
                                    commercial_name = customer?.commercial_name,
                                    incorporation_legal_form = " ", // You may need to get this from your data
                                    incorporation_number = customer?.incorporation_number, // You may need to get this from your data
                                    business = customer?.business, // You may need to get this from your data

                                    phones = new reportTransactionT_to_my_clientTo_entityPhones
                                    {
                                        phone = new reportTransactionT_to_my_clientTo_entityPhonesPhone
                                        {
                                            tph_contact_type = person?.tph_contact_type, // You may need to get this from your data
                                            tph_communication_type = person?.TPH_COMMUNICATION_TYPE, // You may need to get this from your data
                                            tph_country_prefix = person?.tph_country_prefix,
                                            tph_number = person?.tph_number, // You may need to get this from your data
                                            tph_extension = person?.tph_extension // You may need to get this from your data
                                        }
                                    },

                                    addresses = new reportLocation
                                    {
                                        address = new reportLocationAddress
                                        {
                                            address_type = address?.addresstype, // You may need to get this from your data
                                            address = address?.address1, // You may need to get this from your data
                                            city = address?.city, // You may need to get this from your data
                                            country_code = address?.country_code, // You may need to get this from your data
                                            state = address?.state // You may need to get this from your data
                                        }
                                    },

                                    incorporation_state = customer?.incorporation_state, // You may need to get this from your data
                                    incorporation_country_code = customer?.incorporation_country_code, // You may need to get this from your data

                                    /*director_id = GetDirectorDataFromDatabase(transaction.ID), */// Replace with your actual method to get director data

                                    director_id = new TPersonRegistrationInReport
                                    {
                                        gender = person?.sex,
                                        title = person?.title,
                                        first_name = person?.first_name,
                                        last_name = person?.last_name,
                                        birthdate = person?.birthdate,
                                        nationality1 = person?.nationality,
                                        residence = person?.residence,

                                        phones = new TPersonRegistrationInReport.Phones
                                        {
                                            phone = new List<TPhone>
                                        {
                                              new TPhone
                                              {
                                                tph_contact_type = person?.tph_contact_type, // You may need to get this from your data
                                                tph_communication_type = person?.TPH_COMMUNICATION_TYPE, // You may need to get this from your data
                                                tph_country_prefix = person?.tph_country_prefix,
                                                tph_number = person?.tph_number, // You may need to get this from your data
                                                tph_extension = person?.tph_extension // You may need to get this from your data
                                              }
                                            }
                                        },

                                        addresses = new TPersonRegistrationInReport.Addresses
                                        {
                                            address = new List<TAddress>
                                              {
                                                new TAddress
                                                {
                                                address_type = address?.addresstype, // You may need to get this from your data
                                                address = address?.address1, // You may need to get this from your data
                                                city = address?.city, // You may need to get this from your data
                                                country_code = address?.country_code, // You may need to get this from your data
                                                state = address?.state // You may need to get this from your data
                                            }
                                        }
                                        },

                                        occupation = person?.occupation,

                                        identification = new TPersonIdentification
                                        {

                                            type = person?.identifier_code,
                                            number = person?.identifier_number,
                                            issue_date = person?.identifier_issue_date,
                                            expiry_date = person?.identifier_expire_date,
                                            issued_by = person?.identifier_issuer,
                                            issue_country = person?.identifier_country,


                                        },

                                        source_of_wealth = person?.source_of_weqlth,
                                        role = directorData?.role
                                    },

                                    incorporation_date = DateTime.Parse("1999-12-21T00:00:00"), // You may need to get this from your data
                                    comments = transaction?.TRAN_COMMENTS // You may need to populate this based on your data
                                },


                                //    signatory = new List<reportTransactionTFromMyClientFromAccountSignatory>
                                //{
                                //new reportTransactionTFromMyClientFromAccountSignatory

                                signatory = new reportTransactionTFromMyClientFromAccountSignatory
                                {
                                        is_primary = true,
                                 t_person = new TPersonRegistrationInReport
                                {
                                        gender = person?.sex,
                                        title = person?.title,
                                        first_name = person?.first_name,
                                        middle_name = person?.middle_name,
                                        last_name = person?.last_name,
                                        birthdate = person?.birthdate,
                                        birth_place = person?.birth_place,
                                        passport_number = person?.passport_number,
                                        passport_country = person?.passport_issue_country,
                                        id_number = person?.identifier_number,
                                        nationality1 = person?.nationality,
                                        residence = person?.residence,
                                        // Add other personal details here
                         phones = new TPersonRegistrationInReport.Phones
                         {
                            phone = new List<TPhone>
                         {
                            new TPhone
                          {
                                tph_contact_type = person?.tph_contact_type,
                                tph_communication_type = person?.TPH_COMMUNICATION_TYPE,
                                tph_country_prefix = person?.tph_country_prefix,
                                tph_number = person?.tph_number,
                                tph_extension = person?.tph_extension
                            }
                        }
                    },
                    addresses = new TPersonRegistrationInReport.Addresses
                    {
                        address = new List<TAddress>
                        {
                            new TAddress
                            {
                                address_type = address?.addresstype, // You may need to get this from your data
                                address = address?.address1, // You may need to get this from your data
                                city = address?.city, // You may need to get this from your data
                                country_code = address?.country_code, // You may need to get this from your data
                                state = address?.state // You may need to get this from your data
                            }
                        }
                    },
                    // Add other details here

                                occupation = person?.occupation,

                                        identification = new TPersonIdentification
                                        {

                                            type = person?.identifier_code,
                                            number = person?.identifier_number,
                                            issue_date = person?.identifier_issue_date,
                                            expiry_date = person?.identifier_expire_date,
                                            issued_by = person?.identifier_issuer,
                                            issue_country = person?.identifier_country,


                                        },
                                        source_of_wealth = person?.source_of_weqlth,
                                        comments = transaction?.TRAN_COMMENTS,
                },
                role = signatoryData?.role
            },
                                // Add details for additional signatories if needed
                                opened = accountDetails?.opened,
                                balance = transaction?.ACCT_BAL,
                                date_balance = transaction?.ACCT_BAL_DATE,
                                status_code = transaction?.ACCOUNT_STATUS,
                                beneficiary = transaction?.ADDRESS_OF_BENEFICIARY,
                                comments = transaction?.TRAN_COMMENTS

                            },
                            to_country = transaction?.TXN_COUNTRY
                        },


                        t_from = new reportTransactionT_from
                        {
                            from_funds_code = transaction?.DRCR_IND,
                            from_funds_comment = "", // You may need to populate this based on your data

                            from_account = new reportTransactionT_fromFrom_account
                            {
                                institution_name = amlConfigurationData?.institution_name,
                                institution_code = amlConfigurationData?.institution_code,
                                non_bank_institution = false, // You may need to get this from your data
                                account = transaction?.ACCOUNT,
                                account_name = accountDetails?.name,
                            },

                            from_country = transaction?.TXN_COUNTRY // You may need to get this from your data
                        },


                        t_to = new reportTransactionT_to
                        {
                            to_funds_code = transaction?.DRCR_IND,
                            to_funds_comment = " ",
                            to_foreign_currency = new reportTransactionTo_foreign_currency
                            {
                                foreign_currency_code = foreignCurrencyData?.foreign_currency_code,
                                foreign_amount = foreignCurrencyData?.foreign_amount,
                                foreign_exchange_rate = foreignCurrencyData?.foreign_exchange_rate,
                            },
                            to_account = new reportTransactionT_toTo_account
                            {
                                institution_name = amlConfigurationData?.institution_name,
                                institution_code = amlConfigurationData?.institution_code,
                                non_bank_institution = false, // You may need to get this from your data
                                account = transaction?.ACCOUNT,
                                account_name = accountDetails?.name,
                            },
                            to_country = transaction?.TXN_COUNTRY
                        },


                    };


                    transactionDetailsList.Add(transactionDetails);
                }
            }

            return transactionDetailsList;
        }



        private XmlDocument GenerateCTRAMLReport(List<reportTransaction> transactionDetailsList)
        {

          
                XmlDocument xmlDoc = new XmlDocument();
            using (var context = new Entities())
            {

                XmlElement reportElement = xmlDoc.CreateElement("report");
                reportElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                reportElement.SetAttribute("xsi:noNamespaceSchemaLocation", "https://github.com/thecury/goAML/blob/main/goAMLSchema.xsd");
                xmlDoc.AppendChild(reportElement);

                var amlConfigurationData = context.aml_configuration.FirstOrDefault();
                var amlReportingPersonData = context.amlReportingPersons.FirstOrDefault();

                reportElement.AppendChild(CreateElementWithText(xmlDoc, "schema_version", amlConfigurationData?.schema_version ?? ""));
                reportElement.AppendChild(CreateElementWithText(xmlDoc, "rentity_id", amlConfigurationData?.rentity_id.ToString() ?? ""));
                reportElement.AppendChild(CreateElementWithText(xmlDoc, "submission_code", "E"));
                reportElement.AppendChild(CreateElementWithText(xmlDoc, "report_code", "CTR"));
                // Get the current system date in the desired format
                string reportDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
                // Append the report_date element with the formatted date
                reportElement.AppendChild(CreateElementWithText(xmlDoc, "report_date", reportDate));

                reportElement.AppendChild(CreateElementWithText(xmlDoc, "currency_code_local", amlConfigurationData?.currency_code_local ?? ""));
                //reportElement.AppendChild(CreateElementWithText(xmlDoc, "reporting_user_code", "string"));

                // Assuming you have a reference to the parent xmlDoc

                XmlElement reportingPersonElement = xmlDoc.CreateElement("reporting_person");

                reportingPersonElement.AppendChild(CreateElementWithText(xmlDoc, "gender", amlReportingPersonData.sex));
                reportingPersonElement.AppendChild(CreateElementWithText(xmlDoc, "first_name", amlReportingPersonData.first_name));
                reportingPersonElement.AppendChild(CreateElementWithText(xmlDoc, "last_name", amlReportingPersonData.last_name));
                reportingPersonElement.AppendChild(CreateElementWithText(xmlDoc, "birthdate", amlReportingPersonData.birthdate.HasValue ? amlReportingPersonData.birthdate.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null));
                reportingPersonElement.AppendChild(CreateElementWithText(xmlDoc, "birth_place", amlReportingPersonData.birth_place));
                reportingPersonElement.AppendChild(CreateElementWithText(xmlDoc, "id_number", amlReportingPersonData.identifier_number));
                reportingPersonElement.AppendChild(CreateElementWithText(xmlDoc, "nationality1", amlReportingPersonData.nationality));
                reportingPersonElement.AppendChild(CreateElementWithText(xmlDoc, "residence", amlReportingPersonData.residence));

                XmlElement phonesElement = xmlDoc.CreateElement("phones");

                // Create phoneElement
                XmlElement phoneElement = xmlDoc.CreateElement("phone");
                phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", amlReportingPersonData.tph_contact_type));
                phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", amlReportingPersonData.TPH_COMMUNICATION_TYPE));
                phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", amlReportingPersonData.tph_country_prefix));
                phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", amlReportingPersonData.tph_number));
                phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_extension", amlReportingPersonData.tph_extension));

                // Append phoneElement to phonesElement
                phonesElement.AppendChild(phoneElement);

                // Append phonesElement to reportingPersonElement
                reportingPersonElement.AppendChild(phonesElement);

                XmlElement addressesElement = xmlDoc.CreateElement("addresses");
                XmlElement addressElement = xmlDoc.CreateElement("address");
                addressElement.AppendChild(CreateElementWithText(xmlDoc, "address_type", amlReportingPersonData.addressType));
                addressElement.AppendChild(CreateElementWithText(xmlDoc, "address", amlReportingPersonData.address1));
                addressElement.AppendChild(CreateElementWithText(xmlDoc, "city", amlReportingPersonData.city));
                addressElement.AppendChild(CreateElementWithText(xmlDoc, "country_code", amlReportingPersonData.country_code));
                addressElement.AppendChild(CreateElementWithText(xmlDoc, "state", amlReportingPersonData.state));
                addressesElement.AppendChild(addressElement);
                reportingPersonElement.AppendChild(addressesElement);

                reportingPersonElement.AppendChild(CreateElementWithText(xmlDoc, "occupation", amlReportingPersonData.occupation));
                reportElement.AppendChild(reportingPersonElement);


                var groupedTransactions = transactionDetailsList
                    .GroupBy(record => record.transactionnumber)
                    .ToList();

                foreach (var transactionGroup in groupedTransactions)
                {
                    if (transactionGroup.Any())
                    {
                        var firstRecord = transactionGroup.First();

                        XmlElement transactionElement = xmlDoc.CreateElement("transaction");

                        transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transactionnumber", firstRecord.transactionnumber));
                        transactionElement.AppendChild(CreateElementWithText(xmlDoc, "internal_ref_number", " "));
                        transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transaction_location", firstRecord.transaction_location));
                        transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transaction_description", firstRecord.transaction_description));
                        //transactionElement.AppendChild(CreateElementWithText(xmlDoc, "date_transaction", firstRecord.date_transaction));
                        if (!string.IsNullOrEmpty(firstRecord.date_transaction))
                        {
                            DateTime transactionDate = DateTime.Parse(firstRecord.date_transaction);
                            string formattedDate = transactionDate.ToString("yyyy-MM-ddTHH:mm:ss");
                            transactionElement.AppendChild(CreateElementWithText(xmlDoc, "date_transaction", formattedDate));
                        };
                        transactionElement.AppendChild(CreateElementWithText(xmlDoc, "teller", " "));
                        transactionElement.AppendChild(CreateElementWithText(xmlDoc, "authorized", " "));
                        transactionElement.AppendChild(CreateElementWithText(xmlDoc, "late_deposit", " "));
                        //transactionElement.AppendChild(CreateElementWithText(xmlDoc, "value_date", ));
                        transactionElement.AppendChild(CreateElementWithText(xmlDoc, "value_date", firstRecord.value_date));
                        transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transmode_code", firstRecord.transmode_code));
                        transactionElement.AppendChild(CreateElementWithText(xmlDoc, "amount_local", firstRecord.amount_local));

                        // Process the first record as t_from_my_client
                        XmlElement t_from_my_clientElement = xmlDoc.CreateElement("t_from_my_client");
                        t_from_my_clientElement.AppendChild(CreateElementWithText(xmlDoc, "from_funds_code", firstRecord?.t_from_my_client?.from_funds_code ?? ""));
                        t_from_my_clientElement.AppendChild(CreateElementWithText(xmlDoc, "from_funds_comment", firstRecord?.t_from_my_client?.from_funds_comment ?? ""));

                        XmlElement from_accountElement = xmlDoc.CreateElement("from_account");
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "institution_name", firstRecord?.t_from_my_client?.from_account?.institution_name ?? ""));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "institution_code", firstRecord?.t_from_my_client?.from_account?.institution_code ?? ""));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "non_bank_institution", firstRecord?.t_from_my_client?.from_account?.non_bank_institution.ToString()));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "branch", firstRecord?.t_from_my_client?.from_account?.branch ?? ""));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account", firstRecord?.t_from_my_client?.from_account?.account ?? ""));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "currency_code", firstRecord?.t_from_my_client?.from_account?.currency_code ?? ""));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account_name", firstRecord?.t_from_my_client?.from_account?.account_name ?? ""));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "client_number", firstRecord?.t_from_my_client?.from_account?.client_number ?? ""));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "personal_account_type", firstRecord?.t_from_my_client?.from_account?.personal_account_type ?? ""));

                        XmlElement t_entityElement = xmlDoc.CreateElement("t_entity");
                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "name", firstRecord?.t_from_my_client?.from_account?.t_entity?.name ?? ""));
                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "commercial_name", firstRecord?.t_from_my_client?.from_account?.t_entity?.commercial_name ?? ""));
                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "incorporation_legal_form", firstRecord?.t_from_my_client?.from_account?.t_entity?.incorporation_legal_form ?? ""));
                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "incorporation_number", firstRecord?.t_from_my_client?.from_account?.t_entity?.incorporation_number ?? ""));
                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "business", (firstRecord?.t_from_my_client?.from_account?.t_entity?.business).ToString()));

                        XmlElement phonesTFromMyClientElement = xmlDoc.CreateElement("phones");
                        XmlElement phoneTFromMyClientElement = xmlDoc.CreateElement("phone");
                        phoneTFromMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", firstRecord?.t_from_my_client?.from_account?.t_entity?.phones?.phone?.tph_contact_type ?? ""));
                        phoneTFromMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", firstRecord?.t_from_my_client?.from_account?.t_entity?.phones?.phone?.tph_communication_type ?? ""));
                        phoneTFromMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", firstRecord?.t_from_my_client?.from_account?.t_entity?.phones?.phone?.tph_country_prefix ?? ""));
                        phoneTFromMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", firstRecord?.t_from_my_client?.from_account?.t_entity?.phones?.phone?.tph_number ?? ""));
                        phoneTFromMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "tph_extension", firstRecord?.t_from_my_client?.from_account?.t_entity?.phones?.phone?.tph_extension ?? ""));
                        phonesTFromMyClientElement.AppendChild(phoneTFromMyClientElement);

                        t_entityElement.AppendChild(phonesTFromMyClientElement);

                        XmlElement addressesTFromMyClientElement = xmlDoc.CreateElement("addresses");
                        XmlElement addressTFromMyClientElement = xmlDoc.CreateElement("address");
                        addressTFromMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "address_type", firstRecord?.t_from_my_client?.from_account?.t_entity?.addresses?.address?.address_type ?? ""));
                        addressTFromMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "address", firstRecord?.t_from_my_client?.from_account?.t_entity?.addresses?.address?.address ?? ""));
                        addressTFromMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "city", firstRecord?.t_from_my_client?.from_account?.t_entity?.addresses?.address?.city ?? ""));
                        addressTFromMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "country_code", firstRecord?.t_from_my_client?.from_account?.t_entity?.addresses?.address?.country_code ?? ""));
                        addressTFromMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "state", firstRecord?.t_from_my_client?.from_account?.t_entity?.addresses?.address?.state ?? ""));
                        addressesTFromMyClientElement.AppendChild(addressTFromMyClientElement);

                        t_entityElement.AppendChild(addressesTFromMyClientElement);

                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "incorporation_state", firstRecord?.t_from_my_client?.from_account?.t_entity?.incorporation_state ?? ""));
                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "incorporation_country_code", firstRecord?.t_from_my_client?.from_account?.t_entity?.incorporation_country_code ?? ""));

                        XmlElement directorIdElement = xmlDoc.CreateElement("director_id");
                        directorIdElement.AppendChild(CreateElementWithText(xmlDoc, "gender", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.gender));
                        directorIdElement.AppendChild(CreateElementWithText(xmlDoc, "title", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.title));
                        directorIdElement.AppendChild(CreateElementWithText(xmlDoc, "first_name", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.first_name));
                        directorIdElement.AppendChild(CreateElementWithText(xmlDoc, "last_name", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.last_name));
                        directorIdElement.AppendChild(CreateElementWithText(xmlDoc, "birthdate", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.birthdate.ToString()));
                        directorIdElement.AppendChild(CreateElementWithText(xmlDoc, "nationality1", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.nationality1));
                        directorIdElement.AppendChild(CreateElementWithText(xmlDoc, "residence", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.residence));



                        //XmlElement phonesDirectorElement = xmlDoc.CreateElement("phones");
                        //XmlElement phoneDirectorElement = xmlDoc.CreateElement("phone");
                        //phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone?.tph_contact_type));
                        //phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone?.tph_communication_type));
                        //phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone?.tph_country_prefix));
                        //phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone?.tph_number));
                        //phonesDirectorElement.AppendChild(phoneDirectorElement);
                        //directorIdElement.AppendChild(phonesDirectorElement);

                        XmlElement phonesDirectorElement = xmlDoc.CreateElement("phones");

                        // Assuming firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone is a List<TPhone>
                        var phoneDirectorList = firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone;
                        if (phoneDirectorList != null)
                        {
                            foreach (var phone in phoneDirectorList)
                            {
                                XmlElement phoneDirectorElement = xmlDoc.CreateElement("phone");
                                phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", phone?.tph_contact_type ?? ""));
                                phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", phone?.tph_communication_type ?? ""));
                                phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", phone?.tph_country_prefix ?? ""));
                                phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", phone?.tph_number ?? ""));
                                phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_extension", phone?.tph_extension ?? ""));

                                phonesDirectorElement.AppendChild(phoneDirectorElement);
                                directorIdElement.AppendChild(phonesDirectorElement);
                            }
                        }

                        //directorIdElement.AppendChild(phonesDirectorElement);

                        //t_entityElement.AppendChild(phonesDirectorElement);


                        //XmlElement addressesDirectorElement = xmlDoc.CreateElement("addresses");
                        //XmlElement addressDirectorElement = xmlDoc.CreateElement("address");
                        //addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "address_type", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.addresses?.address?.address_type));
                        //addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "address", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.addresses?.address?.address));
                        //addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "city", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.addresses?.address?.city));
                        //addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "country_code", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.addresses?.address?.country_code));
                        //addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "state", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.addresses?.address?.state));
                        //addressesDirectorElement.AppendChild(addressDirectorElement);
                        //directorIdElement.AppendChild(addressesDirectorElement);
                        //t_entityElement.AppendChild(addressesDirectorElement);

                        XmlElement addressesDirectorElement = xmlDoc.CreateElement("addresses");

                        // Assuming firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone is a List<TPhone>
                        var addressDirectorList = firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.addresses?.address;
                        if (addressDirectorList != null)
                        {
                            foreach (var address in addressDirectorList)
                            {
                                XmlElement addressDirectorElement = xmlDoc.CreateElement("address");
                                addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "address_type", address?.address_type ?? ""));
                                addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "address", address?.address ?? ""));
                                addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "city", address?.city ?? ""));
                                addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "country_code", address?.country_code ?? ""));
                                addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "state", address?.state ?? ""));

                                addressesDirectorElement.AppendChild(addressDirectorElement);
                                directorIdElement.AppendChild(addressesDirectorElement);
                            }
                        }



                        directorIdElement.AppendChild(CreateElementWithText(xmlDoc, "occupation", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.occupation));

                        XmlElement identificationElement = xmlDoc.CreateElement("identification");
                        identificationElement.AppendChild(CreateElementWithText(xmlDoc, "type", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.identification?.type));
                        identificationElement.AppendChild(CreateElementWithText(xmlDoc, "number", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.identification?.number));
                        identificationElement.AppendChild(CreateElementWithText(xmlDoc, "issue_date", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.identification?.issue_date.ToString()));
                        identificationElement.AppendChild(CreateElementWithText(xmlDoc, "expiry_date", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.identification?.expiry_date.ToString()));
                        identificationElement.AppendChild(CreateElementWithText(xmlDoc, "issued_by", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.identification?.issued_by));
                        identificationElement.AppendChild(CreateElementWithText(xmlDoc, "issue_country", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.identification?.issue_country));
                        directorIdElement.AppendChild(identificationElement);
                        //t_entityElement.AppendChild(identificationElement);



                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "source_of_wealth", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.source_of_wealth));
                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "role", firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.role));


                        t_entityElement.AppendChild(directorIdElement);
                        // Add directorIdElement to the main XML structure as needed


                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "incorporation_date", firstRecord?.t_from_my_client?.from_account?.t_entity?.incorporation_date.ToString("yyyy-MM-ddTHH:mm:ss") ?? ""));
                        t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "comments", firstRecord?.t_from_my_client?.from_account?.t_entity?.comments ?? ""));


                        from_accountElement.AppendChild(t_entityElement);

                        XmlElement signatoryElement = xmlDoc.CreateElement("signatory");
                        signatoryElement.AppendChild(CreateElementWithText(xmlDoc, "is_primary", firstRecord?.t_from_my_client?.from_account?.signatory?.is_primary.ToString()));

                        XmlElement tPersonSignatoryElement = xmlDoc.CreateElement("t_person");
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "gender", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.gender));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "title", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.title));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "first_name", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.first_name));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "middle_name", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.middle_name));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "last_name", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.last_name));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "birthdate", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.birthdate.ToString()));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "birth_place", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.birth_place));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "passport_number", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.passport_number));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "passport_country", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.passport_country));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "id_number", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.id_number));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "nationality1", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.nationality1));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "residence", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.residence));
                        signatoryElement.AppendChild(tPersonSignatoryElement);



                        //XmlElement phonesSignatoryElement = xmlDoc.CreateElement("phones");
                        //XmlElement phoneSignatoryElement = xmlDoc.CreateElement("phone");
                        //phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.phones?.phone?.tph_contact_type));
                        //phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.phones?.phone?.tph_communication_type));
                        //phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.phones?.phone?.tph_country_prefix));
                        //phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.phones?.phone?.tph_number));
                        //phonesSignatoryElement.AppendChild(phoneSignatoryElement);
                        //signatoryElement.AppendChild(phonesSignatoryElement);

                        XmlElement phonesSignatoryElement = xmlDoc.CreateElement("phones");

                        // Assuming firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone is a List<TPhone>
                        var phoneSignatoryList = firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.phones?.phone;
                        if (phoneSignatoryList != null)
                        {
                            foreach (var phone in phoneSignatoryList)
                            {
                                XmlElement phoneSignatoryElement = xmlDoc.CreateElement("phone");
                                phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", phone?.tph_contact_type ?? ""));
                                phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", phone?.tph_communication_type ?? ""));
                                phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", phone?.tph_country_prefix ?? ""));
                                phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", phone?.tph_number ?? ""));
                                phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_extension", phone?.tph_extension ?? ""));

                                phonesSignatoryElement.AppendChild(phoneSignatoryElement);
                                signatoryElement.AppendChild(phonesSignatoryElement);
                            }
                        }

                        //directorIdElement.AppendChild(phonesDirectorElement);

                        //from_accountElement.AppendChild(phonesSignatoryElement);


                        //XmlElement addressesSignatoryElement = xmlDoc.CreateElement("addresses");
                        //XmlElement addressSignatoryElement = xmlDoc.CreateElement("address");
                        //addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "address_type", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.addresses?.address?.address_type));
                        //addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "address", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.addresses?.address?.address));
                        //addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "city", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.addresses?.address?.city));
                        //addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "country_code", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.addresses?.address?.country_code));
                        //addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "state", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.addresses?.address?.state));
                        //addressesSignatoryElement.AppendChild(addressSignatoryElement);
                        //signatoryElement.AppendChild(addressesSignatoryElement);
                        //from_accountElement.AppendChild(addressesSignatoryElement);


                        XmlElement addressesSignatoryElement = xmlDoc.CreateElement("addresses");

                        // Assuming firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone is a List<TPhone>
                        var addressSignatoryList = firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.addresses?.address;
                        if (addressSignatoryList != null)
                        {
                            foreach (var signatory in addressSignatoryList)
                            {
                                XmlElement addressSignatoryElement = xmlDoc.CreateElement("address");
                                addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "address_type", signatory?.address_type ?? ""));
                                addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "address", signatory?.address ?? ""));
                                addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "city", signatory?.city ?? ""));
                                addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "country_code", signatory?.country_code ?? ""));
                                addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "state", signatory?.state ?? ""));

                                addressesSignatoryElement.AppendChild(addressSignatoryElement);
                                signatoryElement.AppendChild(addressesSignatoryElement);
                            }
                        }


                        signatoryElement.AppendChild(CreateElementWithText(xmlDoc, "occupation", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.occupation));

                        XmlElement identificationSignatoryElement = xmlDoc.CreateElement("identification");
                        identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "type", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.identification?.type));
                        identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "number", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.identification?.number));
                        identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "issue_date", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.identification?.issue_date.ToString()));
                        identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "expiry_date", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.identification?.expiry_date.ToString()));
                        identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "issued_by", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.identification?.issued_by));
                        identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "issue_country", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.identification?.issue_country));
                        signatoryElement.AppendChild(identificationSignatoryElement);
                        //from_accountElement.AppendChild(identificationSignatoryElement);

                        //from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "source_of_wealth", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.source_of_wealth));
                        //from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "comments", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.comments));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "source_of_wealth", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.source_of_wealth));
                        tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "comments", firstRecord?.t_from_my_client?.from_account?.signatory?.t_person?.comments));

                        signatoryElement.AppendChild(CreateElementWithText(xmlDoc, "role", firstRecord?.t_from_my_client?.from_account?.signatory?.role));

                        from_accountElement.AppendChild(signatoryElement);

                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "opened", firstRecord?.t_from_my_client?.from_account?.opened.ToString()));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "balance", firstRecord?.t_from_my_client?.from_account?.balance.ToString()));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "date_balance", firstRecord?.t_from_my_client?.from_account?.date_balance.ToString()));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "status_code", firstRecord?.t_from_my_client?.from_account?.status_code));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "beneficiary", firstRecord?.t_from_my_client?.from_account?.beneficiary));
                        from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "comments", firstRecord?.t_from_my_client?.from_account?.comments));





                        t_from_my_clientElement.AppendChild(from_accountElement);
                        t_from_my_clientElement.AppendChild(CreateElementWithText(xmlDoc, "from_country", firstRecord?.t_from_my_client?.from_country ?? ""));

                        transactionElement.AppendChild(t_from_my_clientElement);




                        if (transactionGroup.Count() > 1)
                        {
                            var secondRecord = transactionGroup.Skip(1).First();

                            // Process the second record as t_to_my_client
                            XmlElement t_to_my_clientElement = xmlDoc.CreateElement("t_to_my_client");
                            t_to_my_clientElement.AppendChild(CreateElementWithText(xmlDoc, "to_funds_code", secondRecord?.t_to_my_client?.to_funds_code));
                            t_to_my_clientElement.AppendChild(CreateElementWithText(xmlDoc, "to_funds_comment", secondRecord?.t_to_my_client?.to_funds_comment));

                            XmlElement to_foreignCurrencyEelement = xmlDoc.CreateElement("to_foreign_currency");
                            to_foreignCurrencyEelement.AppendChild(CreateElementWithText(xmlDoc, "foreign_currency_code", secondRecord?.t_to_my_client?.to_foreign_currency?.foreign_currency_code));
                            to_foreignCurrencyEelement.AppendChild(CreateElementWithText(xmlDoc, "foreign_amount", secondRecord?.t_to_my_client?.to_foreign_currency?.foreign_amount.ToString()));
                            to_foreignCurrencyEelement.AppendChild(CreateElementWithText(xmlDoc, "foreign_exchange_rate", secondRecord?.t_to_my_client?.to_foreign_currency?.foreign_exchange_rate.ToString()));
                            t_to_my_clientElement.AppendChild(to_foreignCurrencyEelement);

                            XmlElement to_accountElement = xmlDoc.CreateElement("to_account");
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "institution_name", secondRecord?.t_to_my_client?.to_account?.institution_name ?? ""));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "institution_code", secondRecord?.t_to_my_client?.to_account?.institution_code ?? ""));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "non_bank_institution", secondRecord?.t_to_my_client?.to_account?.non_bank_institution.ToString()));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "branch", secondRecord?.t_to_my_client?.to_account?.branch ?? ""));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account", secondRecord?.t_to_my_client?.to_account?.account ?? ""));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "currency_code", secondRecord?.t_to_my_client?.to_account?.currency_code ?? ""));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account_name", secondRecord?.t_to_my_client?.to_account?.account_name ?? ""));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "client_number", secondRecord?.t_to_my_client?.to_account?.client_number ?? ""));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "personal_account_type", secondRecord?.t_to_my_client?.to_account?.personal_account_type ?? ""));



                            XmlElement to_t_entityElement = xmlDoc.CreateElement("t_entity");
                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "name", secondRecord?.t_to_my_client?.to_account?.t_entity?.name ?? ""));
                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "commercial_name", secondRecord?.t_to_my_client?.to_account?.t_entity?.commercial_name ?? ""));
                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "incorporation_legal_form", secondRecord?.t_to_my_client?.to_account?.t_entity?.incorporation_legal_form ?? ""));
                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "incorporation_number", secondRecord?.t_to_my_client?.to_account?.t_entity?.incorporation_number ?? ""));
                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "business", (secondRecord?.t_to_my_client?.to_account?.t_entity?.business).ToString()));

                            XmlElement phonesTToMyClientElement = xmlDoc.CreateElement("phones");
                            XmlElement phoneTToMyClientElement = xmlDoc.CreateElement("phone");
                            phoneTToMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", secondRecord?.t_to_my_client?.to_account?.t_entity?.phones?.phone?.tph_contact_type ?? ""));
                            phoneTToMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", secondRecord?.t_to_my_client?.to_account?.t_entity?.phones?.phone?.tph_communication_type ?? ""));
                            phoneTToMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", secondRecord?.t_to_my_client?.to_account?.t_entity?.phones?.phone?.tph_country_prefix ?? ""));
                            phoneTToMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", secondRecord?.t_to_my_client?.to_account?.t_entity?.phones?.phone?.tph_number ?? ""));
                            phoneTToMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "tph_extension", secondRecord?.t_to_my_client?.to_account?.t_entity?.phones?.phone?.tph_extension ?? ""));
                            phonesTToMyClientElement.AppendChild(phoneTToMyClientElement);

                            to_t_entityElement.AppendChild(phonesTToMyClientElement);

                            XmlElement addressesTToMyClientElement = xmlDoc.CreateElement("addresses");
                            XmlElement addressTToMyClientElement = xmlDoc.CreateElement("address");
                            addressTToMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "address_type", secondRecord?.t_to_my_client?.to_account?.t_entity?.addresses?.address?.address_type ?? ""));
                            addressTToMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "address", secondRecord?.t_to_my_client?.to_account?.t_entity?.addresses?.address?.address ?? ""));
                            addressTToMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "city", secondRecord?.t_to_my_client?.to_account?.t_entity?.addresses?.address?.city ?? ""));
                            addressTToMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "country_code", secondRecord?.t_to_my_client?.to_account?.t_entity?.addresses?.address?.country_code ?? ""));
                            addressTToMyClientElement.AppendChild(CreateElementWithText(xmlDoc, "state", secondRecord?.t_to_my_client?.to_account?.t_entity?.addresses?.address?.state ?? ""));
                            addressesTToMyClientElement.AppendChild(addressTToMyClientElement);

                            to_t_entityElement.AppendChild(addressesTToMyClientElement);

                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "incorporation_state", secondRecord?.t_to_my_client?.to_account?.t_entity?.incorporation_state ?? ""));
                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "incorporation_country_code", secondRecord?.t_to_my_client?.to_account?.t_entity?.incorporation_country_code ?? ""));

                            XmlElement directorIdToElement = xmlDoc.CreateElement("director_id");
                            directorIdToElement.AppendChild(CreateElementWithText(xmlDoc, "gender", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.gender));
                            directorIdToElement.AppendChild(CreateElementWithText(xmlDoc, "title", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.title));
                            directorIdToElement.AppendChild(CreateElementWithText(xmlDoc, "first_name", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.first_name));
                            directorIdToElement.AppendChild(CreateElementWithText(xmlDoc, "last_name", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.last_name));
                            directorIdToElement.AppendChild(CreateElementWithText(xmlDoc, "birthdate", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.birthdate.ToString()));
                            directorIdToElement.AppendChild(CreateElementWithText(xmlDoc, "nationality1", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.nationality1));
                            directorIdToElement.AppendChild(CreateElementWithText(xmlDoc, "residence", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.residence));



                            //XmlElement phonesDirectorElement = xmlDoc.CreateElement("phones");
                            //XmlElement phoneDirectorElement = xmlDoc.CreateElement("phone");
                            //phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.phones?.phone?.tph_contact_type));
                            //phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.phones?.phone?.tph_communication_type));
                            //phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.phones?.phone?.tph_country_prefix));
                            //phoneDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.phones?.phone?.tph_number));
                            //phonesDirectorElement.AppendChild(phoneDirectorElement);
                            //directorIdToElement.AppendChild(phonesDirectorElement);

                            XmlElement phonesDirectorToElement = xmlDoc.CreateElement("phones");

                            // Assuming secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.phones?.phone is a List<TPhone>
                            var phoneDirectorToList = secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.phones?.phone;
                            if (phoneDirectorToList != null)
                            {
                                foreach (var phone in phoneDirectorToList)
                                {
                                    XmlElement phoneDirectorToElement = xmlDoc.CreateElement("phone");
                                    phoneDirectorToElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", phone?.tph_contact_type ?? ""));
                                    phoneDirectorToElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", phone?.tph_communication_type ?? ""));
                                    phoneDirectorToElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", phone?.tph_country_prefix ?? ""));
                                    phoneDirectorToElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", phone?.tph_number ?? ""));
                                    phoneDirectorToElement.AppendChild(CreateElementWithText(xmlDoc, "tph_extension", phone?.tph_extension ?? ""));

                                    phonesDirectorToElement.AppendChild(phoneDirectorToElement);
                                    directorIdToElement.AppendChild(phonesDirectorToElement);
                                }
                            }

                            //directorIdToElement.AppendChild(phonesDirectorToElement);

                            //to_t_entityElement.AppendChild(phonesDirectorToElement);


                            //XmlElement addressesDirectorElement = xmlDoc.CreateElement("addresses");
                            //XmlElement addressDirectorElement = xmlDoc.CreateElement("address");
                            //addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "address_type", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.addresses?.address?.address_type));
                            //addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "address", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.addresses?.address?.address));
                            //addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "city", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.addresses?.address?.city));
                            //addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "country_code", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.addresses?.address?.country_code));
                            //addressDirectorElement.AppendChild(CreateElementWithText(xmlDoc, "state", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.addresses?.address?.state));
                            //addressesDirectorElement.AppendChild(addressDirectorElement);
                            //directorIdToElement.AppendChild(addressesDirectorElement);
                            //to_t_entityElement.AppendChild(addressesDirectorElement);

                            XmlElement addressesDirectorToElement = xmlDoc.CreateElement("addresses");

                            // Assuming secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.phones?.phone is a List<TPhone>
                            var addressDirectorToList = secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.addresses?.address;
                            if (addressDirectorToList != null)
                            {
                                foreach (var address in addressDirectorToList)
                                {
                                    XmlElement addressDirectorToElement = xmlDoc.CreateElement("address");
                                    addressDirectorToElement.AppendChild(CreateElementWithText(xmlDoc, "address_type", address?.address_type ?? ""));
                                    addressDirectorToElement.AppendChild(CreateElementWithText(xmlDoc, "address", address?.address ?? ""));
                                    addressDirectorToElement.AppendChild(CreateElementWithText(xmlDoc, "city", address?.city ?? ""));
                                    addressDirectorToElement.AppendChild(CreateElementWithText(xmlDoc, "country_code", address?.country_code ?? ""));
                                    addressDirectorToElement.AppendChild(CreateElementWithText(xmlDoc, "state", address?.state ?? ""));

                                    addressesDirectorToElement.AppendChild(addressDirectorToElement);
                                    directorIdToElement.AppendChild(addressesDirectorToElement);
                                }
                            }



                            directorIdToElement.AppendChild(CreateElementWithText(xmlDoc, "occupation", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.occupation));

                            XmlElement identificationToElement = xmlDoc.CreateElement("identification");
                            identificationToElement.AppendChild(CreateElementWithText(xmlDoc, "type", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.identification?.type));
                            identificationToElement.AppendChild(CreateElementWithText(xmlDoc, "number", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.identification?.number));
                            identificationToElement.AppendChild(CreateElementWithText(xmlDoc, "issue_date", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.identification?.issue_date.ToString()));
                            identificationToElement.AppendChild(CreateElementWithText(xmlDoc, "expiry_date", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.identification?.expiry_date.ToString()));
                            identificationToElement.AppendChild(CreateElementWithText(xmlDoc, "issued_by", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.identification?.issued_by));
                            identificationToElement.AppendChild(CreateElementWithText(xmlDoc, "issue_country", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.identification?.issue_country));
                            directorIdToElement.AppendChild(identificationToElement);
                            //to_t_entityElement.AppendChild(identificationToElement);



                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "source_of_wealth", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.source_of_wealth));
                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "role", secondRecord?.t_to_my_client?.to_account?.t_entity?.director_id?.role));


                            to_t_entityElement.AppendChild(directorIdToElement);
                            // Add directorIdToElement to the main XML structure as needed


                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "incorporation_date", secondRecord?.t_to_my_client?.to_account?.t_entity?.incorporation_date.ToString("yyyy-MM-ddTHH:mm:ss") ?? ""));
                            to_t_entityElement.AppendChild(CreateElementWithText(xmlDoc, "comments", secondRecord?.t_to_my_client?.to_account?.t_entity?.comments ?? ""));


                            to_accountElement.AppendChild(to_t_entityElement);



                            XmlElement tosignatoryElement = xmlDoc.CreateElement("signatory");
                            tosignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "is_primary", secondRecord?.t_to_my_client?.to_account?.signatory?.is_primary.ToString()));

                            XmlElement to_tPersonSignatoryElement = xmlDoc.CreateElement("t_person");
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "gender", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.gender));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "title", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.title));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "first_name", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.first_name));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "middle_name", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.middle_name));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "last_name", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.last_name));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "birthdate", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.birthdate.ToString()));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "birth_place", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.birth_place));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "passport_number", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.passport_number));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "passport_country", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.passport_country));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "id_number", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.id_number));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "nationality1", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.nationality1));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "residence", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.residence));
                            tosignatoryElement.AppendChild(to_tPersonSignatoryElement);



                            //XmlElement phonesSignatoryElement = xmlDoc.CreateElement("phones");
                            //XmlElement phoneSignatoryElement = xmlDoc.CreateElement("phone");
                            //phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.phones?.phone?.tph_contact_type));
                            //phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.phones?.phone?.tph_communication_type));
                            //phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.phones?.phone?.tph_country_prefix));
                            //phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.phones?.phone?.tph_number));
                            //phonesSignatoryElement.AppendChild(phoneSignatoryElement);
                            //signatoryElement.AppendChild(phonesSignatoryElement);

                            XmlElement to_phonesSignatoryElement = xmlDoc.CreateElement("phones");

                            // Assuming firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone is a List<TPhone>
                            var to_phoneSignatoryList = secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.phones?.phone;
                            if (to_phoneSignatoryList != null)
                            {
                                foreach (var phone in to_phoneSignatoryList)
                                {
                                    XmlElement to_phoneSignatoryElement = xmlDoc.CreateElement("phone");
                                    to_phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", phone?.tph_contact_type ?? ""));
                                    to_phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", phone?.tph_communication_type ?? ""));
                                    to_phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", phone?.tph_country_prefix ?? ""));
                                    to_phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", phone?.tph_number ?? ""));
                                    to_phoneSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "tph_extension", phone?.tph_extension ?? ""));

                                    to_phonesSignatoryElement.AppendChild(to_phoneSignatoryElement);
                                    tosignatoryElement.AppendChild(to_phonesSignatoryElement);
                                }
                            }



                            XmlElement to_addressesSignatoryElement = xmlDoc.CreateElement("addresses");

                            // Assuming firstRecord?.t_from_my_client?.from_account?.t_entity?.director_id?.phones?.phone is a List<TPhone>
                            var to_addressSignatoryList = secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.addresses?.address;
                            if (to_addressSignatoryList != null)
                            {
                                foreach (var signatory in to_addressSignatoryList)
                                {
                                    XmlElement to_addressSignatoryElement = xmlDoc.CreateElement("address");
                                    to_addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "address_type", signatory?.address_type ?? ""));
                                    to_addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "address", signatory?.address ?? ""));
                                    to_addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "city", signatory?.city ?? ""));
                                    to_addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "country_code", signatory?.country_code ?? ""));
                                    to_addressSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "state", signatory?.state ?? ""));

                                    to_addressesSignatoryElement.AppendChild(to_addressSignatoryElement);
                                    tosignatoryElement.AppendChild(to_addressesSignatoryElement);
                                }
                            }


                            signatoryElement.AppendChild(CreateElementWithText(xmlDoc, "occupation", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.occupation));

                            XmlElement to_identificationSignatoryElement = xmlDoc.CreateElement("identification");
                            to_identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "type", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.identification?.type));
                            to_identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "number", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.identification?.number));
                            to_identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "issue_date", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.identification?.issue_date.ToString()));
                            to_identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "expiry_date", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.identification?.expiry_date.ToString()));
                            to_identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "issued_by", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.identification?.issued_by));
                            to_identificationSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "issue_country", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.identification?.issue_country));
                            tosignatoryElement.AppendChild(to_identificationSignatoryElement);
                            //from_accountElement.AppendChild(identificationSignatoryElement);

                            //from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "source_of_wealth", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.source_of_wealth));
                            //from_accountElement.AppendChild(CreateElementWithText(xmlDoc, "comments", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.comments));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "source_of_wealth", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.source_of_wealth));
                            to_tPersonSignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "comments", secondRecord?.t_to_my_client?.to_account?.signatory?.t_person?.comments));

                            tosignatoryElement.AppendChild(CreateElementWithText(xmlDoc, "role", secondRecord?.t_to_my_client?.to_account?.signatory?.role));

                            to_accountElement.AppendChild(tosignatoryElement);

                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "opened", secondRecord?.t_to_my_client?.to_account?.opened.ToString()));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "balance", secondRecord?.t_to_my_client?.to_account?.balance.ToString()));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "date_balance", secondRecord?.t_to_my_client?.to_account?.date_balance.ToString()));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "status_code", secondRecord?.t_to_my_client?.to_account?.status_code));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "beneficiary", secondRecord?.t_to_my_client?.to_account?.beneficiary));
                            to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "comments", secondRecord?.t_to_my_client?.to_account?.comments));

                            t_to_my_clientElement.AppendChild(to_accountElement);
                            t_to_my_clientElement.AppendChild(CreateElementWithText(xmlDoc, "to_country", secondRecord?.t_to_my_client?.to_country));

                            transactionElement.AppendChild(t_to_my_clientElement);
                        }


                        // Add logic to handle t_from, t_to elements if needed
                        // ...


                        if (transactionGroup.Count() > 2)
                        {
                            var thirdRecord = transactionGroup.Skip(2).First();
                            // Rest of your code using the thirdRecord

                            XmlElement t_fromElement = xmlDoc.CreateElement("t_from");
                            t_fromElement.AppendChild(CreateElementWithText(xmlDoc, "from_funds_code", thirdRecord?.t_from?.from_funds_code ?? ""));
                            t_fromElement.AppendChild(CreateElementWithText(xmlDoc, "from_funds_comment", thirdRecord?.t_from?.from_funds_comment ?? ""));

                            XmlElement tfrom_accountElement = xmlDoc.CreateElement("from_account");
                            tfrom_accountElement.AppendChild(CreateElementWithText(xmlDoc, "institution_name", thirdRecord?.t_from?.from_account?.institution_name ?? ""));
                            tfrom_accountElement.AppendChild(CreateElementWithText(xmlDoc, "institution_code", thirdRecord?.t_from?.from_account?.institution_code ?? ""));
                            tfrom_accountElement.AppendChild(CreateElementWithText(xmlDoc, "non_bank_institution", thirdRecord?.t_from?.from_account?.non_bank_institution.ToString()));
                            tfrom_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account", thirdRecord?.t_from?.from_account?.account ?? ""));
                            tfrom_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account_name", thirdRecord?.t_from?.from_account?.account_name ?? ""));

                            t_fromElement.AppendChild(tfrom_accountElement);
                            t_fromElement.AppendChild(CreateElementWithText(xmlDoc, "from_country", thirdRecord?.t_from?.from_country ?? ""));

                            transactionElement.AppendChild(t_fromElement);
                        }


                        if (transactionGroup.Count() > 3)
                        {
                            var fourthRecord = transactionGroup.Skip(3).First();
                            // Rest of your code using the thirdRecord


                            XmlElement t_toElement = xmlDoc.CreateElement("t_to");
                            t_toElement.AppendChild(CreateElementWithText(xmlDoc, "from_funds_code", fourthRecord?.t_to?.to_funds_code ?? ""));
                            t_toElement.AppendChild(CreateElementWithText(xmlDoc, "from_funds_comment", fourthRecord?.t_to?.to_funds_comment ?? ""));


                            XmlElement tto_foreignCurrencyElement = xmlDoc.CreateElement("to_foreign_currency");
                            tto_foreignCurrencyElement.AppendChild(CreateElementWithText(xmlDoc, "foreign_currency_code", fourthRecord?.t_to?.to_foreign_currency?.foreign_currency_code ?? ""));
                            tto_foreignCurrencyElement.AppendChild(CreateElementWithText(xmlDoc, "foreign_amount", fourthRecord?.t_to?.to_foreign_currency?.foreign_amount.ToString() ?? ""));
                            tto_foreignCurrencyElement.AppendChild(CreateElementWithText(xmlDoc, "foreign_exchange_rate", fourthRecord?.t_to?.to_foreign_currency?.foreign_exchange_rate.ToString()));
                            t_toElement.AppendChild(tto_foreignCurrencyElement);


                            XmlElement tto_accountElement = xmlDoc.CreateElement("to_account");
                            tto_accountElement.AppendChild(CreateElementWithText(xmlDoc, "institution_name", fourthRecord?.t_to?.to_account?.institution_name ?? ""));
                            tto_accountElement.AppendChild(CreateElementWithText(xmlDoc, "institution_code", fourthRecord?.t_to?.to_account?.institution_code ?? ""));
                            tto_accountElement.AppendChild(CreateElementWithText(xmlDoc, "non_bank_institution", fourthRecord?.t_to?.to_account?.non_bank_institution.ToString()));
                            tto_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account", fourthRecord?.t_to?.to_account?.account ?? ""));
                            tto_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account_name", fourthRecord?.t_to?.to_account?.account_name ?? ""));

                            t_toElement.AppendChild(tto_accountElement);
                            t_toElement.AppendChild(CreateElementWithText(xmlDoc, "to_country", fourthRecord?.t_to?.to_country ?? ""));

                            transactionElement.AppendChild(t_toElement);

                        }


                        reportElement.AppendChild(transactionElement);
                    }
                }

                XmlElement reportIndicatorsElement = xmlDoc.CreateElement("report_indicators");
                reportIndicatorsElement.AppendChild(CreateElementWithText(xmlDoc, "indicator", "-"));
                reportIndicatorsElement.AppendChild(CreateElementWithText(xmlDoc, "indicator", "-"));
                reportElement.AppendChild(reportIndicatorsElement);

                xmlDoc.AppendChild(reportElement);
            }

            return xmlDoc;
        }

        private XmlElement CreateElementWithText(XmlDocument xmlDoc, string elementName, string text)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = text;
            return element;
        }




    }
}
