using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DWBIProjectAPI.Models;

namespace DWBIProjectAPI.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext() : base("Server=ADEGBOYEGAOLUWA\\GBEN;Database=FintrakDWDev;User Id=sa;Password=sqluser10$;"
)
        {
        }

        // DbSet properties for your model classes
        public DbSet<ExposureSummary> ExposureSummaries { get; set; }
        public DbSet<ExposureSummaryMoM> ExposureSummaryMoMs { get; set; }
        public DbSet<TPersonModel> personModels { get; set; }
    }
}