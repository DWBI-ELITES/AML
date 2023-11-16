using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace DWBIProjectAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ... other configurations

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });


       


            // ... other configurations
        }

        public void Configure(IApplicationBuilder app)
        {
            // ... other middleware

            app.UseCors();  // This enables CORS middleware to be used in the pipeline

            // ... other middleware
        }
    }
}
