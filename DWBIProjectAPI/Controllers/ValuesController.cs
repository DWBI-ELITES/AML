using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DWBIProjectAPI.Models; // Import the appropriate namespace for your model class
using System.Data.SqlClient; // Import for SqlParameter
using DWBIProjectAPI.Data;
using System.Web.Http.Cors;

//using System;
using System.IO;
//using System.Linq;
//using System.Web.Http;
using OfficeOpenXml;
using System.Web;



namespace DWBIProjectAPI.Controllers
{
    [RoutePrefix("api/values")] // Apply route prefix to all actions in this controller
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        //private readonly DataDbContext _context = new DataDbContext(); // Adjust the DbContext class name

        //// GET api/values
        //public IEnumerable<string> Get()
        //{ 
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET api/values/digitalloans
        private readonly string _connectionString = "Server=ADEGBOYEGAOLUWA\\GBEN;Database=FintrakDWDev;User Id=sa;Password=sqluser10$;";
        private readonly string _connectionString2 = "Server=ADEGBOYEGAOLUWA\\GBEN;Database=FintrakDWDev_STG;User Id=sa;Password=sqluser10$;";

        public class ExcelProcessingResult
        {
            public bool IsValid { get; set; }
            public ExcelRecord[] Records { get; set; }
        }


   

        [HttpPost]
        [Route("upload-excel")]
        public IHttpActionResult UploadExcelFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    var postedFile = httpRequest.Files[0];
                    if (postedFile.FileName == "LIMIT_DEFINITION.xlsx")
                    {
                        var excelData = YourExcelProcessingLogic(postedFile.InputStream);

                        if (excelData != null && excelData.IsValid)
                        {
                            YourDatabaseTruncateAndInsertLogic(excelData.Records);

                            return Ok("LIMIT_DEFINITION.xlsx uploaded successfully.");
                        }
                        else
                        {
                            return BadRequest("Invalid Excel file structure.");
                        }
                    }
                    else
                    {
                        return BadRequest("Invalid Excel file name.");
                    }
                }
                else
                {
                    return BadRequest("No file was uploaded.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private ExcelProcessingResult YourExcelProcessingLogic(Stream inputStream)
        {
            try
            {
                var records = new List<ExcelRecord>();

                using (var package = new ExcelPackage(inputStream))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                    {
                        try
                        {
                            records.Add(new ExcelRecord
                            {
                                Name = worksheet.Cells[row, 1].GetValue<string>(),
                                Year = worksheet.Cells[row, 2].GetValue<int?>(),
                                Category = worksheet.Cells[row, 3].GetValue<string>(),
                                Limit = worksheet.Cells[row, 4].GetValue<string>(),
                                ThresholdTarget = worksheet.Cells[row, 5].GetValue<string>(),
                                ordernumber = worksheet.Cells[row, 6].GetValue<long?>(),
                                subCategory = worksheet.Cells[row, 7].GetValue<string>(),
                                //ID = worksheet.Cells[row, 8].GetValue<int>(),
                                CategoryCode = worksheet.Cells[row, 9].GetValue<string>()
                            });
                        }
                        catch (Exception ex)
                        {
                            // Log the exception details including the column causing the issue
                            string columnName = worksheet.Cells[row, 1].Address;
                            string errorMessage = $"Error processing Excel row {row}, column {columnName}: {ex.Message}";
                            Console.WriteLine(errorMessage);

                            // Skip this row and continue processing
                        }
                    }
                }

                return new ExcelProcessingResult
                {
                    IsValid = true,
                    Records = records.ToArray()
                };
            }
            catch (Exception)
            {
                return new ExcelProcessingResult
                {
                    IsValid = false,
                    Records = null
                };
            }
        }




        private T GetCellValue<T>(ExcelRange cell)
        {
            if (cell.Value == null)
            {
                return default(T);
            }
            return cell.GetValue<T>();
        }




        private void YourDatabaseTruncateAndInsertLogic(ExcelRecord[] records)
        {
            using (var connection = new SqlConnection(_connectionString2))
            {
                connection.Open();

                // Truncate table
                using (var truncateCommand = new SqlCommand("TRUNCATE TABLE Limit_Definition_", connection))
                {
                    truncateCommand.ExecuteNonQuery();
                }

                // Insert records
                using (var insertCommand = new SqlCommand("INSERT INTO Limit_Definition_ VALUES (@Name, @Year, @Category, @Limit, @ThresholdTarget, @ordernumber, @subCategory, @CategoryCode)", connection))
                {
                    foreach (var record in records)
                    {
                        insertCommand.Parameters.Clear();
                        insertCommand.Parameters.AddWithValue("@Name", record.Name ?? (object)DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@Year", record.Year);
                        insertCommand.Parameters.AddWithValue("@Category", record.Category ?? (object)DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@Limit", record.Limit ?? (object)DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@ThresholdTarget", record.ThresholdTarget ?? (object)DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@ordernumber", record.ordernumber);
                        insertCommand.Parameters.AddWithValue("@subCategory", record.subCategory ?? (object)DBNull.Value);
                        //insertCommand.Parameters.AddWithValue("@ID", record.ID);
                        insertCommand.Parameters.AddWithValue("@CategoryCode", record.CategoryCode ?? (object)DBNull.Value);
                        insertCommand.ExecuteNonQuery();

                    }
                }
            }
        }



        [HttpGet]
        [Route("digitalloans")]
        public IHttpActionResult GetDigitalLoansExposure()
        {
            string query = "SELECT [ExposureAmount] FROM [FintrakDWDev].[EDW].[ExposureSummary] WHERE [ExposureType] = 'Digital Loans'";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    var digitalLoansExposure = command.ExecuteScalar();
                    return Json(digitalLoansExposure);
                }
            }
        }

        // Similar methods for other exposures...


        // GET api/values/directexposure
        [HttpGet]
        [Route("directexposure")]
        public IHttpActionResult GetDirectExposure()
        {
            string query = "SELECT [ExposureAmount] FROM [FintrakDWDev].[EDW].[ExposureSummary] WHERE [ExposureType] = 'Direct Exposure'";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    var directExposure = command.ExecuteScalar();
                    return Json(directExposure);
                }
            }
        }



        // GET api/values/contingentexposure
        [HttpGet]
        [Route("contingentexposure")]
        public IHttpActionResult GetContingentExposure()
        {
            string query = "SELECT [ExposureAmount] FROM [FintrakDWDev].[EDW].[ExposureSummary] WHERE [ExposureType] = 'Contingent Exposure'";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    var contingentExposure = command.ExecuteScalar();
                    return Json(contingentExposure);
                }
            }
        }



        // GET api/values/totalexposure
        [HttpGet]
        [Route("totalexposure")]
        public IHttpActionResult GetTotalExposure()
        {
            string query = "SELECT [ExposureAmount] FROM [FintrakDWDev].[EDW].[ExposureSummary] WHERE [ExposureType] = 'Total Exposure'";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    var totalExposure = command.ExecuteScalar();
                    return Json(totalExposure);
                }
            }
        }



        // GET api/values/madate
        [HttpGet]
        [Route("maxdate")]
        public IHttpActionResult GetMaxDate()
        {
            string query = "SELECT MAX([ProcessingDate]) FROM [FintrakDWDev].[EDW].[ExposureSummary] WHERE [ExposureType] = 'Total Exposure'";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    var maxDate = command.ExecuteScalar();

                    if (maxDate != null && maxDate != DBNull.Value)
                    {
                        DateTime dateValue = Convert.ToDateTime(maxDate);
                        string formattedDate = dateValue.ToString("MMMM d, yyyy");
                        return Json(formattedDate);
                    }
                    else
                    {
                        return NotFound(); // or return appropriate response for no data
                    }
                }
            }
        }



       




        //// POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
