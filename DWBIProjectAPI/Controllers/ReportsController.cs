﻿using System;
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


        // GET api/<controller>
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
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<reportTransaction> transactionDetailsList = new List<reportTransaction>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //string query = "SELECT * FROM [AMLData].[dbo].[txn_live] WHERE CAST(Tran_date AS DATE) BETWEEN @startDate AND @endDate";

                string query = "SELECT a.*, b.name as branch_name, c.swift, c.branch, c.account, c.currency_code, c.name as account_name, c.account_type " +
               "FROM [AMLData].[dbo].[txn_live] a " +
               "LEFT OUTER JOIN [AMLData].[dbo].[amlbranch] b ON a.BRANCH_ID = b.branch_id " +
               "LEFT OUTER JOIN [AMLData].[dbo].[amlAccount] c ON a.CUSTOMER = c.cust_number " +
               "WHERE CAST(Tran_date AS DATE) BETWEEN @startDate AND @endDate";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        string custId = reader["customer"].ToString(); // Assuming there's a column named PERSON_ID

                        List<TPersonModel> personList = GetPerson(custId);

                        TPersonModel person = null; // Declare 'person' here

                        if (personList != null && personList.Count > 0)
                        {
                             person = personList[0];
                            // Now 'person' contains the first TPersonModel in the list
                        }

                        reportTransaction transactionDetails = new reportTransaction
                        {
                            transactionnumber = reader["TRAN_ID"].ToString(),
                            transaction_location = reader["branch_name"].ToString(),
                            transaction_description = reader["TRAN_PARTICULAR"].ToString(),
                            date_transaction = reader["TRAN_DATE"].ToString(),
                            transmode_code = reader["TRAN_TYPE"].ToString(),
                            amount_local = reader["AMOUNT"].ToString(),
                            t_from_my_client = new reportTransactionT_from_my_client
                            {
                                from_funds_code = reader["DRCR_IND"].ToString(),
                                from_person = new reportTransactionT_from_my_clientFrom_person
                                {
                                    first_name = person?.first_name,
                                    last_name = person?.last_name,
                                    birthdate = person?.birthdate ?? DateTime.MinValue,
                                    ssn = person?.ssn,
                                    nationality1 = person?.nationality,
                                    residence = person?.residence,
                                    phones = new reportTransactionT_from_my_clientFrom_personPhones
                                    {
                                        phone = new reportTransactionT_from_my_clientFrom_personPhonesPhone
                                        {
                                            tph_contact_type = person?.tph_contact_type,
                                            tph_communication_type = person?.TPH_COMMUNICATION_TYPE,
                                            tph_country_prefix = person?.tph_country_prefix,
                                            tph_number = person?.tph_number,
                                        }
                                    },
                                    occupation = person?.occupation,
                                },
                                from_country = person?.identifier_country,
                            },
                            t_to_my_client = new reportTransactionT_to_my_client
                            {
                                to_funds_code = reader["DRCR_IND"].ToString(),
                                to_account = new reportTransactionT_to_my_clientTo_account
                                {
                                    institution_name = reader["INSTITUTION_NAME"].ToString(),
                                    swift = reader["swift"].ToString(),
                                    branch = reader["branch"].ToString(),
                                    account = reader["account"].ToString(),
                                    currency_code = reader["currency_code"].ToString(),
                                    account_name = reader["account_name"].ToString(),
                                    client_number = reader["customer"].ToString(),
                                    account_type = reader["account_type"].ToString(),
                                    related_persons = new reportTransactionT_to_my_clientTo_accountRelated_persons
                                    {
                                        account_related_person = new reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_person
                                        {
                                            t_person = new reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_person
                                            {
                                                first_name = person?.first_name,
                                                last_name = person?.last_name,
                                                birthdate = person?.birthdate ?? DateTime.MinValue,
                                                ssn = person?.ssn,
                                                nationality1 = person?.nationality,
                                                residence = person?.residence,
                                                phones = new reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_personPhones
                                                {
                                                    phone = new reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_personPhonesPhone
                                                    {
                                                        tph_contact_type = person?.tph_contact_type,
                                                        tph_communication_type = person?.TPH_COMMUNICATION_TYPE,
                                                        tph_country_prefix = person?.tph_country_prefix,
                                                        tph_number = person?.tph_number
                                                    }
                                                },
                                                occupation = person?.occupation
                                            },
                                            role = "string"
                                        }
                                    },
                                    opened = (DateTime)reader["VALUE_DATE"],

                                    status_code = "I"
                                },
                                //to_country = reader["TO_COUNTRY"].ToString()
                                to_country = reader["TXN_COUNTRY"].ToString()
                            }
                        };

                        transactionDetailsList.Add(transactionDetails);
                    }
                }
            }

            return transactionDetailsList;
        }

        private XmlDocument GenerateCTRAMLReport(List<reportTransaction> transactionDetailsList)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement reportElement = xmlDoc.CreateElement("report");
            reportElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            reportElement.SetAttribute("xsi:noNamespaceSchemaLocation", "https://github.com/thecury/goAML/blob/main/goAMLSchema.xsd");
            xmlDoc.AppendChild(reportElement);

            reportElement.AppendChild(CreateElementWithText(xmlDoc, "schema_version", "string"));
            reportElement.AppendChild(CreateElementWithText(xmlDoc, "rentity_id", "1"));
            reportElement.AppendChild(CreateElementWithText(xmlDoc, "report_code", "CTR"));

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
                    transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transaction_location", firstRecord.transaction_location));
                    transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transaction_description", firstRecord.transaction_description));
                    transactionElement.AppendChild(CreateElementWithText(xmlDoc, "date_transaction", firstRecord.date_transaction));
                    transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transmode_code", firstRecord.transmode_code));
                    transactionElement.AppendChild(CreateElementWithText(xmlDoc, "amount_local", firstRecord.amount_local));

                    // Process the first record as t_from_my_client
                    XmlElement t_from_my_clientElement = xmlDoc.CreateElement("t_from_my_client");
                    t_from_my_clientElement.AppendChild(CreateElementWithText(xmlDoc, "from_funds_code", firstRecord.t_from_my_client.from_funds_code));

                    XmlElement from_personElement = xmlDoc.CreateElement("from_person");
                    from_personElement.AppendChild(CreateElementWithText(xmlDoc, "first_name", firstRecord.t_from_my_client.from_person.first_name));
                    from_personElement.AppendChild(CreateElementWithText(xmlDoc, "last_name", firstRecord.t_from_my_client.from_person.last_name));
                    from_personElement.AppendChild(CreateElementWithText(xmlDoc, "birthdate", firstRecord.t_from_my_client.from_person.birthdate.ToString()));
                    from_personElement.AppendChild(CreateElementWithText(xmlDoc, "ssn", firstRecord.t_from_my_client.from_person.ssn));
                    from_personElement.AppendChild(CreateElementWithText(xmlDoc, "nationality1", firstRecord.t_from_my_client.from_person.nationality1));
                    from_personElement.AppendChild(CreateElementWithText(xmlDoc, "residence", firstRecord.t_from_my_client.from_person.residence));

                    // Add code to handle phonesElement, etc.
                    // ...

                    XmlElement phonesElement = xmlDoc.CreateElement("phones");
                    XmlElement phoneElement = xmlDoc.CreateElement("phone");
                    phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", firstRecord.t_from_my_client.from_person.phones.phone.tph_contact_type));
                    phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", firstRecord.t_from_my_client.from_person.phones.phone.tph_communication_type));
                    phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", firstRecord.t_from_my_client.from_person.phones.phone.tph_country_prefix));
                    phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", firstRecord.t_from_my_client.from_person.phones.phone.tph_number));
                    phonesElement.AppendChild(phoneElement);

                    t_from_my_clientElement.AppendChild(from_personElement);
                    t_from_my_clientElement.AppendChild(CreateElementWithText(xmlDoc, "from_country", firstRecord.t_from_my_client.from_country));

                    transactionElement.AppendChild(t_from_my_clientElement);



                    if (transactionGroup.Count() > 1)
                    {
                        var secondRecord = transactionGroup.Skip(1).First();

                        // Process the second record as t_to_my_client
                        XmlElement t_to_my_clientElement = xmlDoc.CreateElement("t_to_my_client");
                        t_to_my_clientElement.AppendChild(CreateElementWithText(xmlDoc, "to_funds_code", secondRecord.t_to_my_client.to_funds_code));

                        XmlElement to_accountElement = xmlDoc.CreateElement("to_account");
                        to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "institution_name", secondRecord.t_to_my_client.to_account.institution_name));
                        to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "swift", secondRecord.t_to_my_client.to_account.swift));
                        to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "branch", secondRecord.t_to_my_client.to_account.branch));
                        to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account", secondRecord.t_to_my_client.to_account.account));
                        to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "currency_code", secondRecord.t_to_my_client.to_account.currency_code));
                        to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account_name", secondRecord.t_to_my_client.to_account.account_name));
                        to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "client_number", secondRecord.t_to_my_client.to_account.client_number));
                        to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "account_type", secondRecord.t_to_my_client.to_account.account_type));

                        XmlElement related_personsElement = xmlDoc.CreateElement("related_persons");
                        XmlElement account_related_personElement = xmlDoc.CreateElement("account_related_person");
                        XmlElement to_personElement = xmlDoc.CreateElement("to_person");

                        to_personElement.AppendChild(CreateElementWithText(xmlDoc, "first_name", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.t_person.first_name));
                        to_personElement.AppendChild(CreateElementWithText(xmlDoc, "last_name", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.t_person.last_name));
                        to_personElement.AppendChild(CreateElementWithText(xmlDoc, "birthdate", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.t_person.birthdate.ToString()));
                        to_personElement.AppendChild(CreateElementWithText(xmlDoc, "ssn", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.t_person.ssn));
                        to_personElement.AppendChild(CreateElementWithText(xmlDoc, "nationality1", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.t_person.nationality1));
                        to_personElement.AppendChild(CreateElementWithText(xmlDoc, "residence", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.t_person.residence));

                        // Add code to handle phonesElement, etc.
                        // ...


                        //XmlElement phonesElement = xmlDoc.CreateElement("phones");
                        //XmlElement phoneElement = xmlDoc.CreateElement("phone");
                        phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_contact_type", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.t_person.phones.phone.tph_contact_type));
                        phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_communication_type", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.t_person.phones.phone.tph_communication_type));
                        phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_country_prefix", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.t_person.phones.phone.tph_country_prefix));
                        phoneElement.AppendChild(CreateElementWithText(xmlDoc, "tph_number", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.t_person.phones.phone.tph_number));
                        phonesElement.AppendChild(phoneElement);


                        account_related_personElement.AppendChild(to_personElement);
                        account_related_personElement.AppendChild(CreateElementWithText(xmlDoc, "role", secondRecord.t_to_my_client.to_account.related_persons.account_related_person.role));

                        related_personsElement.AppendChild(account_related_personElement);
                        to_accountElement.AppendChild(related_personsElement);

                        to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "opened", secondRecord.t_to_my_client.to_account.opened.ToString()));
                        to_accountElement.AppendChild(CreateElementWithText(xmlDoc, "status_code", secondRecord.t_to_my_client.to_account.status_code));

                        t_to_my_clientElement.AppendChild(to_accountElement);
                        t_to_my_clientElement.AppendChild(CreateElementWithText(xmlDoc, "to_country", secondRecord.t_to_my_client.to_country));

                        transactionElement.AppendChild(t_to_my_clientElement);
                    }


                    // Add logic to handle t_from, t_to elements if needed
                    // ...

                    reportElement.AppendChild(transactionElement);
                }
            }

            XmlElement reportIndicatorsElement = xmlDoc.CreateElement("report_indicators");
            reportIndicatorsElement.AppendChild(CreateElementWithText(xmlDoc, "indicator", "-"));
            reportIndicatorsElement.AppendChild(CreateElementWithText(xmlDoc, "indicator", "-"));
            reportElement.AppendChild(reportIndicatorsElement);

            xmlDoc.AppendChild(reportElement);

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
