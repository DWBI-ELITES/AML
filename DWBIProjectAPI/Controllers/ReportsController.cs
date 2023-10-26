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

namespace DWBIProjectAPI.Controllers
{
    public class ReportsController : ApiController


    {


        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetPerson")]
        public IHttpActionResult GetPerson(string personId)
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<SignatoryUpdateModel> signatoryDetailsPersonList = new List<SignatoryUpdateModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "Select * FROM [AMLData].[dbo].[amlPerson] where personid = @personId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@personId", personId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        SignatoryUpdateModel signatoryDetailsPerson = new SignatoryUpdateModel
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

                        signatoryDetailsPersonList.Add(signatoryDetailsPerson);
                    }
                }
            }

            if (signatoryDetailsPersonList.Count > 0)
            {
                return Ok(signatoryDetailsPersonList);
            }

            return NotFound(); // No signatory details found for the specified personId
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
                ctrXmlDoc.Save("ctr_aml_report.xml");

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

                string query = "SELECT * FROM [AMLData].[dbo].[txn_live] WHERE CAST(Tran_date AS DATE) BETWEEN @startDate AND @endDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        string personId = reader["PERSON_ID"].ToString(); // Assuming there's a column named PERSON_ID

                        SignatoryUpdateModel signatory = GetSignatoryDetailsPerson(personId);

                        reportTransaction transactionDetails = new reportTransaction
                        {
                            transactionnumber = reader["TRAN_ID"].ToString(),
                            transaction_location = reader["BRANCH_ID"].ToString(),
                            transaction_description = reader["TRAN_PARTICULAR"].ToString(),
                            date_transaction = reader["TRAN_DATE"].ToString(),
                            transmode_code = reader["TRAN_TYPE"].ToString(),
                            amount_local = reader["AMOUNT"].ToString(),
                            t_from_my_client = new reportTransactionT_from_my_client
                            {
                                from_funds_code = "D",
                                from_person = new reportTransactionT_from_my_clientFrom_person
                                {
                                    first_name = signatory.first_name,
                                    last_name = signatory.last_name,
                                    //birthdate = (DateTime)reader["BIRTHDATE"],
                                    birthdate = (DateTime)signatory.birthdate,
                                    ssn = signatory.ssn,
                                    nationality1 = signatory.nationality,
                                    residence = signatory.residence,
                                    phones = new reportTransactionT_from_my_clientFrom_personPhones
                                    {
                                        phone = new reportTransactionT_from_my_clientFrom_personPhonesPhone
                                        {
                                            tph_contact_type = signatory.tph_contact_type,
                                            tph_communication_type = signatory.TPH_COMMUNICATION_TYPE,
                                            tph_country_prefix = signatory.tph_country_prefix,
                                            tph_number = signatory.tph_number,
                                        }
                                    },
                                    occupation = signatory.occupation,
                                },
                                from_country = signatory.identifier_country,
                            },
                            t_to_my_client = new reportTransactionT_to_my_client
                            {
                                to_funds_code = "P",
                                to_account = new reportTransactionT_to_my_clientTo_account
                                {
                                    institution_name = reader["INSTITUTION_NAME"].ToString(),
                                    swift = "string",
                                    branch = "string",
                                    account = "string",
                                    currency_code = "OMR",
                                    account_name = "string",
                                    client_number = "string",
                                    account_type = "AC",
                                    related_persons = new reportTransactionT_to_my_clientTo_accountRelated_persons
                                    {
                                        account_related_person = new reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_person
                                        {
                                            t_person = new reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_person
                                            {
                                                first_name = reader["FIRST_NAME"].ToString(),
                                                last_name = reader["LAST_NAME"].ToString(),
                                                //birthdate = DateTime.Parse(reader["BIRTHDATE"].ToString()).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                                                birthdate = DateTime.ParseExact(reader["BIRTHDATE"].ToString(), "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture),
                                                //birthdate = (DateTime)reader["BIRTHDATE"],
                                                ssn = reader["SSN"].ToString(),
                                                nationality1 = reader["NATIONALITY1"].ToString(),
                                                residence = reader["RESIDENCE"].ToString(),
                                                phones = new reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_personPhones
                                                {
                                                    phone = new reportTransactionT_to_my_clientTo_accountRelated_personsAccount_related_personT_personPhonesPhone
                                                    {
                                                        tph_contact_type = "-",
                                                        tph_communication_type = "-",
                                                        tph_country_prefix = "string",
                                                        tph_number = "string"
                                                    }
                                                },
                                                occupation = reader["OCCUPATION"].ToString()
                                            },
                                            role = "OM"
                                        }
                                    },
                                    opened = DateTime.ParseExact(reader["OPENED"].ToString(), "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture),

                                    status_code = "I"
                                },
                                to_country = reader["TO_COUNTRY"].ToString()
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

            foreach (var record in transactionDetailsList)
            {
                XmlElement transactionElement = xmlDoc.CreateElement("transaction");

                transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transactionnumber", record.transactionnumber));
                transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transaction_location", record.transaction_location));
                transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transaction_description", record.transaction_description));
                transactionElement.AppendChild(CreateElementWithText(xmlDoc, "date_transaction", record.date_transaction));
                transactionElement.AppendChild(CreateElementWithText(xmlDoc, "transmode_code", record.transmode_code));
                transactionElement.AppendChild(CreateElementWithText(xmlDoc, "amount_local", record.amount_local));

                // Add logic to handle t_from_my_client, t_to, t_from, t_to_my_client elements


                reportElement.AppendChild(transactionElement);
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
