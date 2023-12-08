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


namespace DWBIProjectAPI.Controllers
{
    public class AccountSearchController : ApiController
    {
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]


        [HttpGet]
        public IHttpActionResult Search()
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //string query = "SELECT account, account_ownership, cust_number FROM amlAccount WHERE account = @SearchValue OR account_ownership = @SearchValue OR cust_number = @SearchValue";
                //string query = "SELECT b.account, b.name, a.cust_id FROM amlCustomer a LEFT OUTER JOIN amlAccount b on a.cust_id = b.cust_number WHERE b.account = @SearchValue OR b.name = @SearchValue OR a.cust_id = @SearchValue";
                string query = "SELECT b.account, b.name, a.cust_id, a.customer_type FROM amlCustomer a LEFT OUTER JOIN amlAccount b on a.cust_id = b.cust_number";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@SearchValue", searchValue);

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);

                    dt.TableName = "SearchResults"; // Set the DataTable's name

                    return Ok(dt);
                }
            }
        }
        //[HttpGet]
        //public IHttpActionResult Search(string searchValue)
        //{
        //    string serverName = "ADEGBOYEGAOLUWA\\GBEN";
        //    string databaseName = "AMLData";

        //    string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        //string query = "SELECT account, account_ownership, cust_number FROM amlAccount WHERE account = @SearchValue OR account_ownership = @SearchValue OR cust_number = @SearchValue";
        //        string query = "SELECT b.account, b.name, a.cust_id FROM amlCustomer a LEFT OUTER JOIN amlAccount b on a.cust_id = b.cust_number WHERE b.account = @SearchValue OR b.name = @SearchValue OR a.cust_id = @SearchValue";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@SearchValue", searchValue);

        //            DataTable dt = new DataTable();
        //            SqlDataAdapter adapter = new SqlDataAdapter(command);
        //            adapter.Fill(dt);

        //            dt.TableName = "SearchResults"; // Set the DataTable's name

        //            return Ok(dt);
        //        }
        //    }
        //}

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetCustomerDetails")]
        public IHttpActionResult GetCustomerDetails(string custId)
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT customer_type, cust_id, bvn, email, update_date, business, commercial_name, incorporation_country_code, name, incorporation_state, tax_number, incorporation_number, incorporation_date, updated_by, business_closed, business_closed_date, address1, addressType, country_code, city, state, zip, tph_contact_type, tph_communication_type, tph_number, tph_extension, source_of_fund, nature_of_txn FROM amlCustomer WHERE cust_id = @CustId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustId", custId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        var customerDetails = new
                        {
                            customer_type = reader["customer_type"],
                            cust_id = reader["cust_id"],
                            bvn = reader["bvn"],
                            email = reader["email"],
                            update_date = reader["update_date"],
                            business = reader["business"],
                            commercial_name = reader["commercial_name"],
                            incorporation_country_code = reader["incorporation_country_code"],
                            name = reader["name"],
                            incorporation_state = reader["incorporation_state"],
                            tax_number = reader["tax_number"],
                            incorporation_number = reader["incorporation_number"],
                            incorporation_date = reader["incorporation_date"],
                            updated_by = reader["updated_by"],
                            business_closed = reader["business_closed"],
                            business_closed_date = reader["business_closed_date"],
                            address1 = reader["address1"],
                            addressType = reader["addressType"],
                            country_code = reader["country_code"],
                            city = reader["city"],
                            state = reader["state"],
                            zip = reader["zip"],
                            tph_contact_type = reader["tph_contact_type"],
                            tph_communication_type = reader["tph_communication_type"],
                            tph_number = reader["tph_number"],
                            tph_extension = reader["tph_extension"],
                            source_of_fund = reader["source_of_fund"],
                            nature_of_txn = reader["nature_of_txn"],

                            // ... (retrieve other fields)
                        };

                        return Ok(customerDetails);
                    }

                    return NotFound(); // No customer with the specified cust_id found
                }
            }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpPut]
        [Route("api/AccountSearch/UpdateCustomerDetails")]
        public IHttpActionResult UpdateCustomerDetails(string custId, [FromBody] CustomerUpdateModel updateModel)
        {
            try
            {
                string serverName = "ADEGBOYEGAOLUWA\\GBEN";
                string databaseName = "AMLData";

                string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = ""; // Initialize the query as an empty string

                    if (updateModel.customer_type == "IC")
                    {
                        updateQuery = "UPDATE amlCustomer " +
                                "SET business = @business, " +
                                "name = @name, customer_type = @customer_type, " +
                                "bvn = @bvn, email = @email, " +
                                "update_date = @update_date, " +
                                "tax_number = @tax_number, " +
                                "updated_by = @updated_by, " +
                                "address1 = @address1, addressType = @addressType, " +
                                "country_code = @country_code, city = @city, " +
                                "state = @state, zip = @zip, " +
                                "tph_contact_type = @tph_contact_type, tph_communication_type = @tph_communication_type, " +
                                "tph_number = @tph_number, tph_extension = @tph_extension, " +
                                "source_of_fund = @source_of_fund, nature_of_txn = @nature_of_txn " +

                                // ... (include other columns)
                                " WHERE cust_id = @custId"; // Add space before WHERE

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {

                            // Set parameters
                            //command.Parameters.AddWithValue("@business", updateModel.business ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@business", updateModel.business);
                            command.Parameters.AddWithValue("@name", updateModel.name);
                            command.Parameters.AddWithValue("@customer_type", updateModel.customer_type);
                            command.Parameters.AddWithValue("@bvn", updateModel.bvn);
                            command.Parameters.AddWithValue("@email", updateModel.email);
                            command.Parameters.AddWithValue("@update_date", updateModel.update_date);
                            command.Parameters.AddWithValue("@tax_number", updateModel.tax_number);
                            command.Parameters.AddWithValue("@updated_by", updateModel.updated_by);
                            command.Parameters.AddWithValue("@address1", updateModel.address1);
                            command.Parameters.AddWithValue("@addressType", updateModel.addressType);
                            command.Parameters.AddWithValue("@country_code", updateModel.country_code);
                            command.Parameters.AddWithValue("@city", updateModel.city);
                            command.Parameters.AddWithValue("@state", updateModel.state);
                            command.Parameters.AddWithValue("@zip", updateModel.zip);
                            command.Parameters.AddWithValue("@tph_contact_type", updateModel.tph_contact_type);
                            command.Parameters.AddWithValue("@tph_communication_type", updateModel.tph_communication_type);
                            command.Parameters.AddWithValue("@tph_number", updateModel.tph_number);
                            command.Parameters.AddWithValue("@tph_extension", updateModel.tph_extension);
                            command.Parameters.AddWithValue("@source_of_fund", updateModel.source_of_fund);
                            command.Parameters.AddWithValue("@nature_of_txn", updateModel.nature_of_txn);
                            // ... (set other parameters)
                            command.Parameters.AddWithValue("@custId", custId);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                return Ok("Customer details updated successfully!");
                            }
                            else
                            {
                                return BadRequest("No records updated. Customer not found.");
                            }
                        }
                    }
                    else if (updateModel.customer_type == "CC")
                    {
                        updateQuery = "UPDATE amlCustomer " +
                                "SET business = @business, " +
                                "name = @name, customer_type = @customer_type, " +
                                "bvn = @bvn, email = @email, " +
                                "update_date = @update_date, commercial_name = @commercial_name, " +
                                "incorporation_country_code = @incorporation_country_code, incorporation_state = @incorporation_state, " +
                                "tax_number = @tax_number, incorporation_number = @incorporation_number, " +
                                "incorporation_date = @incorporation_date, updated_by = @updated_by, " +
                                "business_closed = @business_closed, business_closed_date = @business_closed_date, " +
                                "address1 = @address1, addressType = @addressType, " +
                                "country_code = @country_code, city = @city, " +
                                "state = @state, zip = @zip, " +
                                "tph_contact_type = @tph_contact_type, tph_communication_type = @tph_communication_type, " +
                                "tph_number = @tph_number, tph_extension = @tph_extension, " +
                                "source_of_fund = @source_of_fund, nature_of_txn = @nature_of_txn " +

                                // ... (include other columns)
                                " WHERE cust_id = @custId"; // Add space before WHERE

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {

                            // Set parameters
                            //command.Parameters.AddWithValue("@business", updateModel.business ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@business", updateModel.business);
                            command.Parameters.AddWithValue("@name", updateModel.name);
                            command.Parameters.AddWithValue("@customer_type", updateModel.customer_type);
                            command.Parameters.AddWithValue("@bvn", updateModel.bvn);
                            command.Parameters.AddWithValue("@email", updateModel.email);
                            command.Parameters.AddWithValue("@update_date", updateModel.update_date);
                            command.Parameters.AddWithValue("@commercial_name", updateModel.commercial_name);
                            command.Parameters.AddWithValue("@incorporation_country_code", updateModel.incorporation_country_code);
                            command.Parameters.AddWithValue("@incorporation_state", updateModel.incorporation_state);
                            command.Parameters.AddWithValue("@tax_number", updateModel.tax_number);
                            command.Parameters.AddWithValue("@incorporation_number", updateModel.incorporation_number);
                            command.Parameters.AddWithValue("@incorporation_date", updateModel.incorporation_date);
                            command.Parameters.AddWithValue("@updated_by", updateModel.updated_by);
                            command.Parameters.AddWithValue("@business_closed", updateModel.business_closed);
                            command.Parameters.AddWithValue("@business_closed_date", updateModel.business_closed_date);
                            command.Parameters.AddWithValue("@address1", updateModel.address1);
                            command.Parameters.AddWithValue("@addressType", updateModel.addressType);
                            command.Parameters.AddWithValue("@country_code", updateModel.country_code);
                            command.Parameters.AddWithValue("@city", updateModel.city);
                            command.Parameters.AddWithValue("@state", updateModel.state);
                            command.Parameters.AddWithValue("@zip", updateModel.zip);
                            command.Parameters.AddWithValue("@tph_contact_type", updateModel.tph_contact_type);
                            command.Parameters.AddWithValue("@tph_communication_type", updateModel.tph_communication_type);
                            command.Parameters.AddWithValue("@tph_number", updateModel.tph_number);
                            command.Parameters.AddWithValue("@tph_extension", updateModel.tph_extension);
                            command.Parameters.AddWithValue("@source_of_fund", updateModel.source_of_fund);
                            command.Parameters.AddWithValue("@nature_of_txn", updateModel.nature_of_txn);
                            // ... (set other parameters)
                            command.Parameters.AddWithValue("@custId", custId);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                return Ok("Customer details updated successfully!");
                            }
                            else
                            {
                                return BadRequest("No records updated. Customer not found.");
                            }
                        }
                    }
                    else
                    {
                        // Handle unsupported customer types or other scenarios
                        return BadRequest("Invalid customer type.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and errors appropriately
                return InternalServerError(ex);
            }
        }



        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetAccountDetails")]
        public IHttpActionResult GetAccountDetails(string aCCOUNT)
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT account, account_officer, account_ownership, account_type, balance, balance_date, branch, cust_number, closed, comments, currency_code, entity_cre_flg, iban, name, new_account, opened, previous_status, schm_code, schm_type, status, status_date, swift, temp_account, frez_reason_code, acct_cls_date, acct_cls_flg, clr_bal_amt, cum_cr_amt, cum_dr_amt, drwng_power, frez_code, last_tran_date_cr, last_tran_date_dr, fx_cum_cr_amt, fx_cum_dr_amt, sanct_lim, last_tran_date FROM [AMLData].[dbo].[amlAccount] WHERE account = @Account";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Account", aCCOUNT);

                    SqlDataReader reader = command.ExecuteReader();


                    if (reader.Read())
                    {
                        var accountDetails = new
                        {
                            account = reader["account"],
                            account_officer = reader["account_officer"],
                            account_ownership = reader["account_ownership"],
                            account_type = reader["account_type"],
                            balance = reader["balance"],
                            balance_date = reader["balance_date"],
                            branch = reader["branch"],
                            cust_number = reader["cust_number"],
                            closed = reader["closed"],
                            comments = reader["comments"],
                            currency_code = reader["currency_code"],
                            entity_cre_flg = reader["entity_cre_flg"],
                            iban = reader["iban"],
                            name = reader["name"],
                            new_account = reader["new_account"],
                            opened = reader["opened"],
                            previous_status = reader["previous_status"],
                            schm_code = reader["schm_code"],
                            schm_type = reader["schm_type"],
                            status = reader["status"],
                            status_date = reader["status_date"],
                            swift = reader["swift"],
                            temp_account = reader["temp_account"],
                            frez_reason_code = reader["frez_reason_code"],
                            acct_cls_date = reader["acct_cls_date"],
                            acct_cls_flg = reader["acct_cls_flg"],
                            clr_bal_amt = reader["clr_bal_amt"],
                            cum_cr_amt = reader["cum_cr_amt"],
                            cum_dr_amt = reader["cum_dr_amt"],
                            drwng_power = reader["drwng_power"],
                            frez_code = reader["frez_code"],
                            last_tran_date_cr = reader["last_tran_date_cr"],
                            last_tran_date_dr = reader["last_tran_date_dr"],
                            fx_cum_cr_amt = reader["fx_cum_cr_amt"],
                            fx_cum_dr_amt = reader["fx_cum_dr_amt"],
                            sanct_lim = reader["sanct_lim"],
                            last_tran_date = reader["last_tran_date"],

                            // ... (retrieve other fields)
                        };

                        return Ok(accountDetails);
                    }

                    return NotFound(); // No account with the specified account found
                }
            }
        }


        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetSignatoryDetails")]
        public IHttpActionResult GetSignatoryDetails(string aCCOUNT)
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<object> signatoryDetailsList = new List<object>(); // Create a list to hold signatory details

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "Select identifier_number, last_name, first_name FROM [AMLData].[dbo].[amlPerson] a  inner join [AMLData].[dbo].[amlSignatory] b on a.PERSONID = b.person_id where b.account = @aCCOUNT";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Account", aCCOUNT);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var signatoryDetails = new
                        {
                            identifier_number = reader["identifier_number"],
                            last_name = reader["last_name"],
                            first_name = reader["first_name"],
                        };

                        signatoryDetailsList.Add(signatoryDetails);
                    }
                }
            }

            if (signatoryDetailsList.Count > 0)
            {
                return Ok(signatoryDetailsList);
            }

            return NotFound(); // No signatory details found for the specified account
        }



        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetDirectorDetails")]
        public IHttpActionResult GetDirectorDetails(string custId)
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<object> directorDetailsList = new List<object>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "Select identifier_number, last_name, first_name FROM [AMLData].[dbo].[amlPerson] a  inner join [AMLData].[dbo].[amlDirector] b on a.PERSONID = b.person_id where b.customer_id = @custID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustId", custId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var directorDetails = new
                        {
                            identifier_number = reader["identifier_number"],
                            last_name = reader["last_name"],
                            first_name = reader["first_name"],
                        };

                        directorDetailsList.Add(directorDetails);
                    }
                }
            }

            if (directorDetailsList.Count > 0)
            {
                return Ok(directorDetailsList);
            }

            return NotFound(); // No customer with the specified cust_id found

        }


        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetSignatoryFullDetails")]
        public IHttpActionResult GetSignatoryFullDetails(string identifierNumber)
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT  PERSONID, birth_place, birthdate, cust_id, deceased, deceased_date, email, employer_name, first_name, foreigner, identifier_code, identifier_country, identifier_expire_date, identifier_issue_date, identifier_issuer, identifier_number, identifier_other, identifier_state, issuer_id, last_name, lga_of_origin, middle_name, mothers_name, nationality, nok_address1, nok_address2, nok_email, nok_name, nok_phone, nok_relationship, occupation, p_add_address1, p_add_address2, p_add_city, p_add_country_code, p_add_state, p_add_zip, p_alias, passport_number, passport_issue_country, prefix_name, RECORD_STATUS, referee_person_id, reference_code, residence, sex, source_of_weqlth, ssn, foreigner_date_arrival, foreigner_nationality, foreigner_passport_exp_dt, foreigner_passport_iss_dt, foreigner_passport_number, foreigner_permit_number, foreigner_permit_valid_from, foreigner_permit_valid_to, foreigner_visa_number, tax_comments, tax_number, tax_reg_number, title, update_date, updated_by, address_id, phone_id, addressType, address1, address2, town, city, zip, country_code, state, tph_contact_type, tph_country_prefix, tph_number, tph_extension, tph_fax, tph_communication_type FROM amlPerson WHERE identifier_number = @IdentifierNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdentifierNumber", identifierNumber);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        var signatoryFullDetails = new
                        {
                            PERSONID = reader["PERSONID"],
                            birth_place = reader["birth_place"],
                            birthdate = reader["birthdate"],
                            cust_id = reader["cust_id"],
                            deceased = reader["deceased"],
                            deceased_date = reader["deceased_date"],
                            email = reader["email"],
                            employer_name = reader["employer_name"],
                            first_name = reader["first_name"],
                            foreigner = reader["foreigner"],
                            identifier_code = reader["identifier_code"],
                            identifier_country = reader["identifier_country"],
                            identifier_expire_date = reader["identifier_expire_date"],
                            identifier_issue_date = reader["identifier_issue_date"],
                            identifier_issuer = reader["identifier_issuer"],
                            identifier_number = reader["identifier_number"],
                            identifier_other = reader["identifier_other"],
                            identifier_state = reader["identifier_state"],
                            issuer_id = reader["issuer_id"],
                            last_name = reader["last_name"],
                            lga_of_origin = reader["lga_of_origin"],
                            middle_name = reader["middle_name"],
                            mothers_name = reader["mothers_name"],
                            nationality = reader["nationality"],
                            nok_address1 = reader["nok_address1"],
                            nok_address2 = reader["nok_address2"],
                            nok_email = reader["nok_email"],
                            nok_name = reader["nok_name"],
                            nok_phone = reader["nok_phone"],
                            nok_relationship = reader["nok_relationship"],
                            occupation = reader["occupation"],
                            p_add_address1 = reader["p_add_address1"],
                            p_add_address2 = reader["p_add_address2"],
                            p_add_city = reader["p_add_city"],
                            p_add_country_code = reader["p_add_country_code"],
                            p_add_state = reader["p_add_state"],
                            p_add_zip = reader["p_add_zip"],
                            p_alias = reader["p_alias"],
                            passport_number = reader["passport_number"],
                            passport_issue_country = reader["passport_issue_country"],
                            prefix_name = reader["prefix_name"],
                            RECORD_STATUS = reader["RECORD_STATUS"],
                            referee_person_id = reader["referee_person_id"],
                            reference_code = reader["reference_code"],
                            residence = reader["residence"],
                            sex = reader["sex"],
                            source_of_weqlth = reader["source_of_weqlth"],
                            ssn = reader["ssn"],
                            foreigner_date_arrival = reader["foreigner_date_arrival"],
                            foreigner_nationality = reader["foreigner_nationality"],
                            foreigner_passport_exp_dt = reader["foreigner_passport_exp_dt"],
                            foreigner_passport_iss_dt = reader["foreigner_passport_iss_dt"],
                            foreigner_passport_number = reader["foreigner_passport_number"],
                            foreigner_permit_number = reader["foreigner_permit_number"],
                            foreigner_permit_valid_from = reader["foreigner_permit_valid_from"],
                            foreigner_permit_valid_to = reader["foreigner_permit_valid_to"],
                            foreigner_visa_number = reader["foreigner_visa_number"],
                            tax_comments = reader["tax_comments"],
                            tax_number = reader["tax_number"],
                            tax_reg_number = reader["tax_reg_number"],
                            title = reader["title"],
                            update_date = reader["update_date"],
                            updated_by = reader["updated_by"],
                            address_id = reader["address_id"],
                            phone_id = reader["phone_id"],
                            addressType = reader["addressType"],
                            address1 = reader["address1"],
                            address2 = reader["address2"],
                            town = reader["town"],
                            city = reader["city"],
                            zip = reader["zip"],
                            country_code = reader["country_code"],
                            state = reader["state"],
                            tph_contact_type = reader["tph_contact_type"],
                            tph_country_prefix = reader["tph_country_prefix"],
                            tph_number = reader["tph_number"],
                            tph_extension = reader["tph_extension"],
                            tph_fax = reader["tph_fax"],
                            tph_communication_type = reader["tph_communication_type"],

                            // ... (retrieve other fields)
                        };

                        return Ok(signatoryFullDetails);
                    }

                    return NotFound(); // No customer with the specified cust_id found
                }
            }
        }



        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpPut]
        [Route("api/AccountSearch/UpdateSignatoryDetails")]
        public IHttpActionResult UpdateSignatoryDetails(string identifierNumber, [FromBody] SignatoryUpdateModel updateSignatoryModel)
        {
            try
            {
                string serverName = "ADEGBOYEGAOLUWA\\GBEN";
                string databaseName = "AMLData";

                string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // First, update amlPerson
                    string updatePersonQuery = "UPDATE amlPerson " +
                                               "SET identifier_code = @identifier_code, identifier_issuer = @identifier_issuer, identifier_issue_date = @identifier_issue_date,  " +
                                               "identifier_expire_date = @identifier_expire_date, passport_issue_country = @passport_issue_country, " +
                                               "identifier_state = @identifier_state, title = @title, " +
                                               "first_name = @first_name, middle_name = @middle_name, " +
                                               "last_name = @last_name, sex = @sex, " +
                                               "birthdate = @birthdate, birth_place = @birth_place, " +
                                               "mothers_name = @mothers_name, tax_number = @tax_number, " +
                                               "source_of_weqlth = @source_of_weqlth, occupation = @occupation, " +
                                               "residence = @residence, town = @town, " +
                                               "address1 = @address1, addressType = @addressType, " +
                                               "p_add_address1 = @p_add_address1, p_add_address2 = @p_add_address2, " +
                                               "city = @city, state = @state, " +
                                               "zip = @zip, country_code = @country_code, employer_name = @employer_name, " +
                                               "tph_contact_type = @tph_contact_type, tph_country_prefix = @tph_country_prefix, " +
                                               "tph_number = @tph_number, tph_extension = @tph_extension, " +
                                               "foreigner_date_arrival = @foreigner_date_arrival, foreigner_nationality = @foreigner_nationality, " +
                                               "foreigner_passport_number = @foreigner_passport_number, foreigner_permit_number = @foreigner_permit_number, " +
                                               "foreigner_visa_number = @foreigner_visa_number, foreigner_permit_valid_from = @foreigner_permit_valid_from, " +
                                               "foreigner_permit_valid_to = @foreigner_permit_valid_to " +

                                               "WHERE identifier_number = @identifierNumber";

                    using (SqlCommand personCommand = new SqlCommand(updatePersonQuery, connection))
                    {
                        //personCommand.Parameters.AddWithValue("@personid", updateSignatoryModel.personid);
                        personCommand.Parameters.AddWithValue("@identifier_code", updateSignatoryModel.identifier_code);
                        personCommand.Parameters.AddWithValue("@identifier_issuer", updateSignatoryModel.identifier_issuer);
                        personCommand.Parameters.AddWithValue("@identifier_issue_date", updateSignatoryModel.identifier_issue_date);
                        personCommand.Parameters.AddWithValue("@identifier_expire_date", updateSignatoryModel.identifier_expire_date);
                        personCommand.Parameters.AddWithValue("@passport_issue_country", updateSignatoryModel.passport_issue_country);
                        personCommand.Parameters.AddWithValue("@identifier_state", updateSignatoryModel.identifier_state);
                        personCommand.Parameters.AddWithValue("@title", updateSignatoryModel.title);
                        personCommand.Parameters.AddWithValue("@first_name", updateSignatoryModel.first_name);
                        personCommand.Parameters.AddWithValue("@middle_name", updateSignatoryModel.middle_name);
                        personCommand.Parameters.AddWithValue("@last_name", updateSignatoryModel.last_name);
                        personCommand.Parameters.AddWithValue("@sex", updateSignatoryModel.sex);
                        personCommand.Parameters.AddWithValue("@birthdate", updateSignatoryModel.birthdate);
                        personCommand.Parameters.AddWithValue("@birth_place", updateSignatoryModel.birth_place);
                        personCommand.Parameters.AddWithValue("@mothers_name", updateSignatoryModel.mothers_name);
                        personCommand.Parameters.AddWithValue("@tax_number", updateSignatoryModel.tax_number);
                        personCommand.Parameters.AddWithValue("@source_of_weqlth", updateSignatoryModel.source_of_weqlth);
                        personCommand.Parameters.AddWithValue("@occupation", updateSignatoryModel.occupation);
                        personCommand.Parameters.AddWithValue("@residence", updateSignatoryModel.residence);
                        personCommand.Parameters.AddWithValue("@town", updateSignatoryModel.town);
                        personCommand.Parameters.AddWithValue("@address1", updateSignatoryModel.address1);
                        personCommand.Parameters.AddWithValue("@addressType", updateSignatoryModel.addressType);
                        personCommand.Parameters.AddWithValue("@p_add_address1", updateSignatoryModel.p_add_address1);
                        personCommand.Parameters.AddWithValue("@p_add_address2", updateSignatoryModel.p_add_address2);
                        personCommand.Parameters.AddWithValue("@city", updateSignatoryModel.city);
                        personCommand.Parameters.AddWithValue("@state", updateSignatoryModel.state);
                        personCommand.Parameters.AddWithValue("@zip", updateSignatoryModel.zip);
                        personCommand.Parameters.AddWithValue("@country_code", updateSignatoryModel.country_code);
                        personCommand.Parameters.AddWithValue("@employer_name", updateSignatoryModel.employer_name);
                        personCommand.Parameters.AddWithValue("@tph_contact_type", updateSignatoryModel.tph_contact_type);
                        personCommand.Parameters.AddWithValue("@tph_country_prefix", updateSignatoryModel.tph_country_prefix);
                        personCommand.Parameters.AddWithValue("@tph_number", updateSignatoryModel.tph_number);
                        personCommand.Parameters.AddWithValue("@tph_extension", updateSignatoryModel.tph_extension);
                        personCommand.Parameters.AddWithValue("@foreigner_date_arrival", updateSignatoryModel.foreigner_date_arrival);
                        personCommand.Parameters.AddWithValue("@foreigner_nationality", updateSignatoryModel.foreigner_nationality);
                        personCommand.Parameters.AddWithValue("@foreigner_passport_number", updateSignatoryModel.foreigner_passport_number);
                        personCommand.Parameters.AddWithValue("@foreigner_permit_number", updateSignatoryModel.foreigner_permit_number);
                        personCommand.Parameters.AddWithValue("@foreigner_visa_number", updateSignatoryModel.foreigner_visa_number);
                        personCommand.Parameters.AddWithValue("@foreigner_permit_valid_from", updateSignatoryModel.foreigner_permit_valid_from);
                        personCommand.Parameters.AddWithValue("@foreigner_permit_valid_to", updateSignatoryModel.foreigner_permit_valid_to);

                        personCommand.Parameters.AddWithValue("@identifierNumber", identifierNumber);

                        int personRowsAffected = personCommand.ExecuteNonQuery();

                        // If amlPerson was updated successfully, update amlAddress
                        if (personRowsAffected > 0)
                        {
                            string updateAddressQuery = "UPDATE amlAddress " +
                                                        "SET town = @town, address1 = @address1, " +
                                                        "addresstype = @addressType, city = @city, " +
                                                        "state = @state, zip = @zip, house_number = @house_number, " +
                                                        "country_code = @country_code  " +
                                                        "WHERE address_id = @address_id";

                            using (SqlCommand addressCommand = new SqlCommand(updateAddressQuery, connection))
                            {
                                addressCommand.Parameters.AddWithValue("@town", updateSignatoryModel.town);
                                addressCommand.Parameters.AddWithValue("@address1", updateSignatoryModel.address1);
                                addressCommand.Parameters.AddWithValue("@addresstype", updateSignatoryModel.addressType);
                                addressCommand.Parameters.AddWithValue("@city", updateSignatoryModel.city);
                                addressCommand.Parameters.AddWithValue("@state", updateSignatoryModel.state);
                                addressCommand.Parameters.AddWithValue("@zip", updateSignatoryModel.zip);
                                addressCommand.Parameters.AddWithValue("@country_code", updateSignatoryModel.country_code);
                                addressCommand.Parameters.AddWithValue("@house_number", updateSignatoryModel.residence);
                                addressCommand.Parameters.AddWithValue("@address_id", updateSignatoryModel.address_id);

                                int addressRowsAffected = addressCommand.ExecuteNonQuery();

                                // If amlAddress was updated successfully, update amlPhone
                                if (addressRowsAffected > 0)
                                {
                                    string updatePhoneQuery = "UPDATE amlPhone " +
                                                              "SET tph_contact_type = @tph_contact_type, " +
                                                              // "tph_communication_type = @tph_communication_type, tph_country_prefix = @tph_country_prefix, " +
                                                              "tph_country_prefix = @tph_country_prefix, " +
                                                              "tph_extension = @tph_extension, tph_number = @tph_number " +
                                                              "WHERE phone_id = @phone_id";

                                    using (SqlCommand phoneCommand = new SqlCommand(updatePhoneQuery, connection))
                                    {
                                        phoneCommand.Parameters.AddWithValue("@tph_contact_type", updateSignatoryModel.tph_contact_type);
                                        phoneCommand.Parameters.AddWithValue("@tph_country_prefix", updateSignatoryModel.tph_country_prefix);
                                        phoneCommand.Parameters.AddWithValue("@tph_extension", updateSignatoryModel.tph_extension);
                                        phoneCommand.Parameters.AddWithValue("@tph_number", updateSignatoryModel.tph_number);
                                        // phoneCommand.Parameters.AddWithValue("@tph_communication_type", updateSignatoryModel.tph_communication_type);
                                        phoneCommand.Parameters.AddWithValue("@phone_id", updateSignatoryModel.phone_id);

                                        int phoneRowsAffected = phoneCommand.ExecuteNonQuery();

                                        if (phoneRowsAffected > 0)
                                        {
                                            return Ok("Signatory details, address, and phone updated successfully!");
                                        }
                                    }
                                }
                            }
                        }

                        return BadRequest("No records updated. Signatory not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and errors appropriately
                return InternalServerError(ex);
            }
        }


        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetTitles")]
        public IHttpActionResult GetTitles()
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<string> titles = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ShortTitle FROM [AMLData].[dbo].[TitleLookup]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        titles.Add(reader["ShortTitle"].ToString());
                    }
                }
            }

            return Ok(titles);
        }




        //public class IdentifierType
        //{
        //    public string Item { get; set; }
        //    public string Description { get; set; }
        //}

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetIdentifierTypes")]
        public IHttpActionResult GetIdentifierTypes()
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";
            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<IdentifierType> identifierTypes = new List<IdentifierType>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT [Item], [Description] FROM [AMLData].[dbo].[IdentifierType]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        IdentifierType identifierType = new IdentifierType
                        {
                            Item = reader["Item"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                        identifierTypes.Add(identifierType);
                    }
                }
            }

            return Ok(identifierTypes);
        }



        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/AccountSearch/InsertAmlPerson")]
        public IHttpActionResult InsertAmlPerson([FromBody] SignatoryUpdateModel newPerson, string aCCOUNT, string identifierNumber)

        {
            try
            {
                string serverName = "ADEGBOYEGAOLUWA\\GBEN";
                string databaseName = "AMLData";
                string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //string selectQuery = "SELECT COUNT(*) FROM amlPerson WHERE identifier_number = @identifier_number";
                    string selectQuery = "SELECT COUNT(*) FROM amlPerson WHERE identifier_number = @identifierNumber";

                    int existingRecordCount;

                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@identifierNumber", newPerson.identifier_number);
                        existingRecordCount = (int)selectCommand.ExecuteScalar();
                    }

                    if (existingRecordCount > 0)
                    {
                        string updateQuery = "INSERT INTO amlSignatory (person_id, primary_sig, role, account) " +
                                                                         "VALUES (@PERSONID,'1','SIGNATORY', @aCCOUNT)";

                        using (SqlCommand insertCommand = new SqlCommand(updateQuery, connection))
                        {
                            // Loop through all properties of SignatoryUpdateModel
                            foreach (var property in typeof(SignatoryUpdateModel).GetProperties())
                            {
                                string propertyName = property.Name;
                                var value = property.GetValue(newPerson);

                                // If the value is null, set it to DBNull.Value
                                insertCommand.Parameters.AddWithValue($"@{propertyName}", value ?? DBNull.Value);
                            }

                            // Add parameter for aCCOUNT
                            insertCommand.Parameters.AddWithValue("@aCCOUNT", aCCOUNT);

                            int insertrowsAffected = insertCommand.ExecuteNonQuery();

                            if (insertrowsAffected > 0)
                            {
                                return Ok("Record inserted successfully");
                            }
                            else
                            {
                                return BadRequest("Failed to insert record");
                            }
                        }


                    }
                    else
                    {
                        string insertQuery = "INSERT INTO amlPerson (PERSONID, birth_place, birthdate, cust_id, deceased, deceased_date, email, employer_name, first_name, " +
                                                "foreigner, identifier_code, identifier_country, identifier_expire_date, identifier_issue_date, identifier_issuer, identifier_number, " +
                                                "identifier_other, identifier_state, issuer_id, last_name, lga_of_origin, middle_name, mothers_name, nationality, nok_address1, " +
                                                "nok_address2, nok_email, nok_name, nok_phone, nok_relationship, occupation, p_add_address1, p_add_address2, p_add_city, " +
                                                "p_add_country_code, p_add_state, p_add_zip, p_alias, passport_number, passport_issue_country, prefix_name, RECORD_STATUS, " +
                                                "referee_person_id, reference_code, residence, sex, source_of_weqlth, ssn, foreigner_date_arrival, foreigner_nationality, " +
                                                "foreigner_passport_exp_dt, foreigner_passport_iss_dt, foreigner_passport_number, foreigner_permit_number, " +
                                                "foreigner_permit_valid_from, foreigner_permit_valid_to, foreigner_visa_number, tax_comments, tax_number, tax_reg_number, " +
                                                "title, update_date, updated_by, address_id, phone_id, addressType, address1, address2, town, city, zip, country_code, " +
                                                "state, tph_contact_type, tph_country_prefix, tph_number, tph_extension, tph_fax, tph_communication_type) " +
                                                "VALUES (@PERSONID, @birth_place, @birthdate, @cust_id, @deceased, @deceased_date, @email, " +
                                                "@employer_name, @first_name, @foreigner, @identifier_code, @identifier_country, @identifier_expire_date, @identifier_issue_date, " +
                                                "@identifier_issuer, @identifier_number, @identifier_other, @identifier_state, @issuer_id, @last_name, @lga_of_origin, " +
                                                "@middle_name, @mothers_name, @nationality, @nok_address1, @nok_address2, @nok_email, @nok_name, @nok_phone, @nok_relationship, " +
                                                "@occupation, @p_add_address1, @p_add_address2, @p_add_city, @p_add_country_code, @p_add_state, @p_add_zip, @p_alias, " +
                                                "@passport_number, @passport_issue_country, @prefix_name, @RECORD_STATUS, @referee_person_id, @reference_code, @residence, " +
                                                "@sex, @source_of_weqlth, @ssn, @foreigner_date_arrival, @foreigner_nationality, @foreigner_passport_exp_dt, " +
                                                "@foreigner_passport_iss_dt, @foreigner_passport_number, @foreigner_permit_number, @foreigner_permit_valid_from, " +
                                                "@foreigner_permit_valid_to, @foreigner_visa_number, @tax_comments, @tax_number, @tax_reg_number, @title, @update_date, " +
                                                "@updated_by, @address_id, @phone_id, @addressType, @address1, @address2, @town, @city, @zip, @country_code, " +
                                                "@state, @tph_contact_type, @tph_country_prefix, @tph_number, @tph_extension, @tph_fax, @tph_communication_type) " +
                                                "INSERT INTO amlAddress (town, address1, addresstype, city, state, zip, house_number,country_code, address_id) " +
                                                                      "VALUES (@town, @address1, @addresstype, @city, @state, @zip, @residence, @country_code, @address_id) " +
                                                                       "INSERT INTO amlPhone (tph_contact_type, tph_country_prefix, tph_extension, phone_id, tph_communication_type ) " +
                                                                      "VALUES (@tph_contact_type, @tph_country_prefix, @tph_extension, @phone_id, @tph_communication_type ) " +
                                                                        "INSERT INTO amlSignatory (person_id, primary_sig, role, account) " +
                                                                         "VALUES (@PERSONID,'1','SIGNATORY', @aCCOUNT)";

                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            // Loop through all properties of SignatoryUpdateModel
                            foreach (var property in typeof(SignatoryUpdateModel).GetProperties())
                            {
                                string propertyName = property.Name;
                                var value = property.GetValue(newPerson);

                                // If the value is null, set it to DBNull.Value
                                insertCommand.Parameters.AddWithValue($"@{propertyName}", value ?? DBNull.Value);
                            }

                            // Add parameter for aCCOUNT
                            insertCommand.Parameters.AddWithValue("@aCCOUNT", aCCOUNT);

                            int insertrowsAffected = insertCommand.ExecuteNonQuery();

                            if (insertrowsAffected > 0)
                            {
                                return Ok("Record inserted successfully");
                            }
                            else
                            {
                                return BadRequest("Failed to insert record");
                            }
                        }
                    }
                }

                //return BadRequest("Failed to update or insert record"); // Add a default return value if needed
            }
            catch (Exception ex)
            {
                // Handle exceptions and errors appropriately
                return InternalServerError(ex);
            }
        }



        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/AccountSearch/InsertAmlPersonDirector")]
        public IHttpActionResult InsertAmlPersonDirector([FromBody] SignatoryUpdateModel newDirector, string customerID, string identifierNumber)

        {
            try
            {
                string serverName = "ADEGBOYEGAOLUWA\\GBEN";
                string databaseName = "AMLData";
                string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //string selectQuery = "SELECT COUNT(*) FROM amlPerson WHERE identifier_number = @identifier_number";
                    string selectQuery = "SELECT COUNT(*) FROM amlPerson WHERE identifier_number = @identifierNumber";

                    int existingRecordCount;

                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@identifierNumber", newDirector.identifier_number);
                        existingRecordCount = (int)selectCommand.ExecuteScalar();
                    }

                    if (existingRecordCount > 0)
                    {
                        string updateQuery = "INSERT INTO amlDirector (person_id, role, customer_id) " +
                                                                         "VALUES (@PERSONID,'DIRECTOR', @customerID)";

                        using (SqlCommand insertCommand = new SqlCommand(updateQuery, connection))
                        {
                            // Loop through all properties of SignatoryUpdateModel
                            foreach (var property in typeof(SignatoryUpdateModel).GetProperties())
                            {
                                string propertyName = property.Name;
                                var value = property.GetValue(newDirector);

                                // If the value is null, set it to DBNull.Value
                                insertCommand.Parameters.AddWithValue($"@{propertyName}", value ?? DBNull.Value);
                            }

                            // Add parameter for aCCOUNT
                            insertCommand.Parameters.AddWithValue("@customerID", customerID);

                            int insertrowsAffected = insertCommand.ExecuteNonQuery();

                            if (insertrowsAffected > 0)
                            {
                                return Ok("Record inserted successfully");
                            }
                            else
                            {
                                return BadRequest("Failed to insert record");
                            }
                        }


                    }
                    else
                    {
                        string insertQuery = "INSERT INTO amlPerson (PERSONID, birth_place, birthdate, cust_id, deceased, deceased_date, email, employer_name, first_name, " +
                                                "foreigner, identifier_code, identifier_country, identifier_expire_date, identifier_issue_date, identifier_issuer, identifier_number, " +
                                                "identifier_other, identifier_state, issuer_id, last_name, lga_of_origin, middle_name, mothers_name, nationality, nok_address1, " +
                                                "nok_address2, nok_email, nok_name, nok_phone, nok_relationship, occupation, p_add_address1, p_add_address2, p_add_city, " +
                                                "p_add_country_code, p_add_state, p_add_zip, p_alias, passport_number, passport_issue_country, prefix_name, RECORD_STATUS, " +
                                                "referee_person_id, reference_code, residence, sex, source_of_weqlth, ssn, foreigner_date_arrival, foreigner_nationality, " +
                                                "foreigner_passport_exp_dt, foreigner_passport_iss_dt, foreigner_passport_number, foreigner_permit_number, " +
                                                "foreigner_permit_valid_from, foreigner_permit_valid_to, foreigner_visa_number, tax_comments, tax_number, tax_reg_number, " +
                                                "title, update_date, updated_by, address_id, phone_id, addressType, address1, address2, town, city, zip, country_code, " +
                                                "state, tph_contact_type, tph_country_prefix, tph_number, tph_extension, tph_fax, tph_communication_type) " +
                                                "VALUES (@PERSONID, @birth_place, @birthdate, @cust_id, @deceased, @deceased_date, @email, " +
                                                "@employer_name, @first_name, @foreigner, @identifier_code, @identifier_country, @identifier_expire_date, @identifier_issue_date, " +
                                                "@identifier_issuer, @identifier_number, @identifier_other, @identifier_state, @issuer_id, @last_name, @lga_of_origin, " +
                                                "@middle_name, @mothers_name, @nationality, @nok_address1, @nok_address2, @nok_email, @nok_name, @nok_phone, @nok_relationship, " +
                                                "@occupation, @p_add_address1, @p_add_address2, @p_add_city, @p_add_country_code, @p_add_state, @p_add_zip, @p_alias, " +
                                                "@passport_number, @passport_issue_country, @prefix_name, @RECORD_STATUS, @referee_person_id, @reference_code, @residence, " +
                                                "@sex, @source_of_weqlth, @ssn, @foreigner_date_arrival, @foreigner_nationality, @foreigner_passport_exp_dt, " +
                                                "@foreigner_passport_iss_dt, @foreigner_passport_number, @foreigner_permit_number, @foreigner_permit_valid_from, " +
                                                "@foreigner_permit_valid_to, @foreigner_visa_number, @tax_comments, @tax_number, @tax_reg_number, @title, @update_date, " +
                                                "@updated_by, @address_id, @phone_id, @addressType, @address1, @address2, @town, @city, @zip, @country_code, " +
                                                "@state, @tph_contact_type, @tph_country_prefix, @tph_number, @tph_extension, @tph_fax, @tph_communication_type) " +
                                                "INSERT INTO amlAddress (town, address1, addresstype, city, state, zip, house_number,country_code, address_id) " +
                                                                      "VALUES (@town, @address1, @addresstype, @city, @state, @zip, @residence, @country_code, @address_id) " +
                                                                       "INSERT INTO amlPhone (tph_contact_type, tph_country_prefix, tph_extension, phone_id, tph_communication_type ) " +
                                                                      "VALUES (@tph_contact_type, @tph_country_prefix, @tph_extension, @phone_id, @tph_communication_type ) " +
                                                                        "INSERT INTO amlDirector (person_id, role, customer_id) " +
                                                                         "VALUES (@PERSONID,'DIRECTOR', @customerID)";

                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            // Loop through all properties of SignatoryUpdateModel
                            foreach (var property in typeof(SignatoryUpdateModel).GetProperties())
                            {
                                string propertyName = property.Name;
                                var value = property.GetValue(newDirector);

                                // If the value is null, set it to DBNull.Value
                                insertCommand.Parameters.AddWithValue($"@{propertyName}", value ?? DBNull.Value);
                            }

                            // Add parameter for aCCOUNT
                            insertCommand.Parameters.AddWithValue("@customerID", customerID);

                            int insertrowsAffected = insertCommand.ExecuteNonQuery();

                            if (insertrowsAffected > 0)
                            {
                                return Ok("Record inserted successfully");
                            }
                            else
                            {
                                return BadRequest("Failed to insert record");
                            }
                        }
                    }
                }

                //return BadRequest("Failed to update or insert record"); // Add a default return value if needed
            }
            catch (Exception ex)
            {
                // Handle exceptions and errors appropriately
                return InternalServerError(ex);
            }
        }

        //[HttpPost]
        //[Route("api/AccountSearch/InsertAmlPerson")]
        //public IHttpActionResult InsertAmlPerson([FromBody] SignatoryUpdateModel newPerson, string aCCOUNT)
        //{
        //    try
        //    {
        //        string serverName = "ADEGBOYEGAOLUWA\\GBEN";
        //        string databaseName = "AMLData";

        //        string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

        //        //string PERSONId = $"{newPerson.identifier_code}-{newPerson.identifier_number}";                // Concatenating identifierCode and identifierNumber

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            string insertQuery = "INSERT INTO amlPerson (PERSONID, birth_place, birthdate, cust_id, deceased, deceased_date, email, employer_name, first_name, " +
        //                                "foreigner, identifier_code, identifier_country, identifier_expire_date, identifier_issue_date, identifier_issuer, identifier_number, " +
        //                                "identifier_other, identifier_state, issuer_id, last_name, lga_of_origin, middle_name, mothers_name, nationality, nok_address1, " +
        //                                "nok_address2, nok_email, nok_name, nok_phone, nok_relationship, occupation, p_add_address1, p_add_address2, p_add_city, " +
        //                                "p_add_country_code, p_add_state, p_add_zip, p_alias, passport_number, passport_issue_country, prefix_name, RECORD_STATUS, " +
        //                                "referee_person_id, reference_code, residence, sex, source_of_weqlth, ssn, foreigner_date_arrival, foreigner_nationality, " +
        //                                "foreigner_passport_exp_dt, foreigner_passport_iss_dt, foreigner_passport_number, foreigner_permit_number, " +
        //                                "foreigner_permit_valid_from, foreigner_permit_valid_to, foreigner_visa_number, tax_comments, tax_number, tax_reg_number, " +
        //                                "title, update_date, updated_by, address_id, phone_id, addressType, address1, address2, town, city, zip, country_code, " +
        //                                "state, tph_contact_type, tph_country_prefix, tph_number, tph_extension, tph_fax, tph_communication_type) " +
        //                                "VALUES (@PERSONID, @birth_place, @birthdate, @cust_id, @deceased, @deceased_date, @email, " +
        //                                "@employer_name, @first_name, @foreigner, @identifier_code, @identifier_country, @identifier_expire_date, @identifier_issue_date, " +
        //                                "@identifier_issuer, @identifier_number, @identifier_other, @identifier_state, @issuer_id, @last_name, @lga_of_origin, " +
        //                                "@middle_name, @mothers_name, @nationality, @nok_address1, @nok_address2, @nok_email, @nok_name, @nok_phone, @nok_relationship, " +
        //                                "@occupation, @p_add_address1, @p_add_address2, @p_add_city, @p_add_country_code, @p_add_state, @p_add_zip, @p_alias, " +
        //                                "@passport_number, @passport_issue_country, @prefix_name, @RECORD_STATUS, @referee_person_id, @reference_code, @residence, " +
        //                                "@sex, @source_of_weqlth, @ssn, @foreigner_date_arrival, @foreigner_nationality, @foreigner_passport_exp_dt, " +
        //                                "@foreigner_passport_iss_dt, @foreigner_passport_number, @foreigner_permit_number, @foreigner_permit_valid_from, " +
        //                                "@foreigner_permit_valid_to, @foreigner_visa_number, @tax_comments, @tax_number, @tax_reg_number, @title, @update_date, " +
        //                                "@updated_by, @address_id, @phone_id, @addressType, @address1, @address2, @town, @city, @zip, @country_code, " +
        //                                "@state, @tph_contact_type, @tph_country_prefix, @tph_number, @tph_extension, @tph_fax, @tph_communication_type) " +
        //                                "INSERT INTO amlAddress (town, address1, addresstype, city, state, zip, house_number,country_code, address_id) " +
        //                                                      "VALUES (@town, @address1, @addresstype, @city, @state, @zip, @residence, @country_code, @address_id) " +
        //                                                       "INSERT INTO amlPhone (tph_contact_type, tph_country_prefix, tph_extension, phone_id, tph_communication_type ) " +
        //                                                      "VALUES (@tph_contact_type, @tph_country_prefix, @tph_extension, @phone_id, @tph_communication_type ) " +
        //                                                        "INSERT INTO amlSignatory (person_id, primary_sig, role, account) " +
        //                                                         "VALUES (@PERSONID,'1','SIGNATORY', @aCCOUNT)";
        //            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
        //            {
        //                // Loop through all properties of SignatoryUpdateModel
        //                foreach (var property in typeof(SignatoryUpdateModel).GetProperties())
        //                {
        //                    string propertyName = property.Name;
        //                    var value = property.GetValue(newPerson);

        //                    // If the value is null, set it to DBNull.Value
        //                    insertCommand.Parameters.AddWithValue($"@{propertyName}", value ?? DBNull.Value);
        //                }

        //                // Add parameter for aCCOUNT
        //                insertCommand.Parameters.AddWithValue("@aCCOUNT", aCCOUNT);

        //                int rowsAffected = insertCommand.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    return Ok("Record inserted successfully");
        //                }
        //                else
        //                {
        //                    return BadRequest("Failed to insert record");
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions and errors appropriately
        //        return InternalServerError(ex);
        //    }
        //}




        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/ReplaceCharacters")]
        public IHttpActionResult ReplaceCharacters(string country, string identifierNumber, string identifierCode)
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";
            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            string result = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT [ISSUER_NAME], COUNTRY_CODE 
                FROM [AMLData].[dbo].[RADAR_IDENTITY_FORMAT] 
                WHERE ID_FORMAT_SEQUENCE = (
                    SELECT 
                        Concat(
                            (SELECT CountryCode FROM [AMLData].[dbo].[amlCountry] WHERE Country = @Country), 
                            '-', 
                            (SELECT dbo.ReplaceCharacters(@IdentifierNumber))
                        )
                ) and  FIU_IDENTITY = (SELECT [FIU_IDENTITY]   FROM [AMLData].[dbo].[RADAR_FIU_IDENTITY]  WHERE [FIU_CODE] = @IdentifierCode)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@IdentifierNumber", identifierNumber);
                    command.Parameters.AddWithValue("@IdentifierCode", identifierCode);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        result = $"Issuer Name: {reader["ISSUER_NAME"]}, Country Code: {reader["COUNTRY_CODE"]}";
                    }
                    else
                    {
                        result = "No data found.";
                    }
                }
            }

            return Ok(result);
        }




        public class Countries
        {
            public string Country { get; set; }
            public string CountryCode { get; set; }
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetCountries")]
        public IHttpActionResult GetCountries()
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";
            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<Countries> countries = new List<Countries>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT [CountryCode],[Country] FROM [AMLData].[dbo].[amlCountry]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Countries country = new Countries
                        {
                            Country = reader["Country"].ToString(),
                            CountryCode = reader["CountryCode"].ToString()
                        };
                        countries.Add(country);
                    }
                }
            }

            return Ok(countries);
        }



        //public class ContactType
        //{
        //    public string Item { get; set; }
        //    public string Description { get; set; }
        //}


        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetContactTypes")]
        public IHttpActionResult GetContactTypes()
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";
            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<ContactType> contactTypes = new List<ContactType>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT [Item], [Description] FROM [AMLData].[dbo].[ContactType]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ContactType contactType = new ContactType
                        {
                            Item = reader["Item"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                        contactTypes.Add(contactType);
                    }
                }
            }

            return Ok(contactTypes);
        }


        //public class GenderType
        //{
        //    public string Item { get; set; }
        //    public string Description { get; set; }
        //}

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetGenderTypes")]
        public IHttpActionResult GetGenderTypes()
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";
            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<GenderType> genderTypes = new List<GenderType>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT [Item], [Description] FROM [AMLData].[dbo].[GenderType]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        GenderType genderType = new GenderType
                        {
                            Item = reader["Item"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                        genderTypes.Add(genderType);
                    }
                }
            }

            return Ok(genderTypes);
        }



        //public class CommunicationType
        //{
        //    public string Item { get; set; }
        //    public string Description { get; set; }
        //}

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/AccountSearch/GetCommunicationTypes")]
        public IHttpActionResult GetCommunicationTypes()
        {
            string serverName = "ADEGBOYEGAOLUWA\\GBEN";
            string databaseName = "AMLData";
            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            List<CommunicationType> communicationTypes = new List<CommunicationType>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT [Item], [Description] FROM [AMLData].[dbo].[CommunicationType]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CommunicationType communicationType = new CommunicationType
                        {
                            Item = reader["Item"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                        communicationTypes.Add(communicationType);
                    }
                }
            }

            return Ok(communicationTypes);
        }





        //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        //[HttpGet]
        //[Route("api/AccountSearch/GetTransactions")]
        //public IHttpActionResult GetTransactions(string startDate, string endDate)
        //{
        //    string serverName = "ADEGBOYEGAOLUWA\\GBEN";
        //    string databaseName = "AMLData";

        //    string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

        //    List<object> transactionDetailsList = new List<object>();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string query = "SELECT * FROM [AMLData].[dbo].[txn_live] WHERE CAST(Tran_date AS DATE) BETWEEN @startDate AND @endDate";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@startDate", startDate);
        //            command.Parameters.AddWithValue("@endDate", endDate);

        //            SqlDataReader reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                var transactionDetails = new
        //                {
        //                    ID = reader["ID"],
        //                    ACCOUNT_STATUS = reader["ACCOUNT_STATUS"],
        //                    ACCT_BAL = reader["ACCT_BAL"],
        //                    ACCT_BAL_DATE = reader["ACCT_BAL_DATE"],
        //                    AMOUNT = reader["AMOUNT"],
        //                    AUTH_IP_ADDRESS = reader["AUTH_IP_ADDRESS"],
        //                    BRANCH_ID = reader["BRANCH_ID"],
        //                    CHEQUE_TXN = reader["CHEQUE_TXN"],
        //                    DELETED = reader["DELETED"],
        //                    DELETED_BY = reader["DELETED_BY"],
        //                    DELETED_DATE = reader["DELETED_DATE"],
        //                    DRCR_IND = reader["DRCR_IND"],
        //                    ENTRY_TIME = reader["ENTRY_TIME"],
        //                    FX_AMOUNT = reader["FX_AMOUNT"],
        //                    INIT_BRANCH_ID = reader["INIT_BRANCH_ID"],
        //                    INP_IP_ADDRESS = reader["INP_IP_ADDRESS"],
        //                    INSTITUTION_CODE = reader["INSTITUTION_CODE"],
        //                    INSTITUTION_NAME = reader["INSTITUTION_NAME"],
        //                    OTHER_BANK_ACCOUNT = reader["OTHER_BANK_ACCOUNT"],
        //                    OTHER_BANK_ACCT_NAME = reader["OTHER_BANK_ACCT_NAME"],
        //                    PERSON_TYPE = reader["PERSON_TYPE"],
        //                    POSTED = reader["POSTED"],
        //                    POSTED_DATE = reader["POSTED_DATE"],
        //                    RATE = reader["RATE"],
        //                    SCHM_CODE = reader["SCHM_CODE"],
        //                    SCHM_TYPE = reader["SCHM_TYPE"],
        //                    SERIAL_NUM = reader["SERIAL_NUM"],
        //                    TRAN_CURRENCY = reader["TRAN_CURRENCY"],
        //                    TRAN_DATE = reader["TRAN_DATE"],
        //                    TRAN_ID = reader["TRAN_ID"],
        //                    TRAN_PARTICULAR = reader["TRAN_PARTICULAR"],
        //                    TRAN_SUB_TYPE = reader["TRAN_SUB_TYPE"],
        //                    TRAN_TYPE = reader["TRAN_TYPE"],
        //                    VALUE_DATE = reader["VALUE_DATE"],
        //                    ACCOUNT = reader["ACCOUNT"],
        //                    AUTHORISER = reader["AUTHORISER"],
        //                    CUSTOMER = reader["CUSTOMER"],
        //                    INPUTTER_USER_ID = reader["INPUTTER_USER_ID"],
        //                    PERSON_ID = reader["PERSON_ID"],
        //                    TXN_COUNTRY = reader["TXN_COUNTRY"],
        //                    CONTRACT_TYPE = reader["CONTRACT_TYPE"],
        //                    CONTRACT_NAME = reader["CONTRACT_NAME"],
        //                    CHQ_FLAG = reader["CHQ_FLAG"],
        //                    ORG_SERIAL = reader["ORG_SERIAL"],
        //                    TRAN_COMMENTS = reader["TRAN_COMMENTS"],
        //                    BATCH_TRANS = reader["BATCH_TRANS"],
        //                    ADDRESS_OF_BENEFICIARY = reader["ADDRESS_OF_BENEFICIARY"],
        //                    PURPOSE_OF_TRANSACTION = reader["PURPOSE_OF_TRANSACTION"],
        //                    KYC_ID = reader["KYC_ID"]
        //                };

        //                transactionDetailsList.Add(transactionDetails);
        //            }
        //        }
        //    }

        //    if (transactionDetailsList.Count > 0)
        //    {
        //        return Ok(transactionDetailsList);
        //    }

        //    return NotFound(); // No transactions found for the specified dates
        //}

















    }
}
