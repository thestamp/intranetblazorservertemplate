using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntranetServerTemplate.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IntranetServerTemplate.Core.Data
{
    public class DataContext : DbContext
    {
        /*
         * I just want to create a database for this project
         *      1) dotnet ef database update --project .\IntranetServerTemplate.Core --startup-project .\IntranetServerTemplate.Web
         *
         */

        /*
         * Adding EF to existing Project
         * 1) Copy this Datacontext class
         * 2) Add DbSets to your data model classes
         * 3) Add the following project references:
         *      IntranetServerTemplate.Web:
         *          - Microsoft.EntityFrameworkCore.SqlServer
         *          - Microsoft.EntityFrameworkCore.Design (if doing migrations)
         *      IntranetServerTemplate.Core:
         *          - Microsoft.EntityFrameworkCore.SqlServer
         *
         * 4) Add the following section to appsettings (edit to match your database - https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings#aspnet-core)
         *    "ConnectionStrings": {
         *       "IntranetServerTemplateDataContext": "Server=(localdb)\\mssqllocaldb;Database=IntranetServerTemplate;Trusted_Connection=True;"
         *       },
         * 5) Add the following to Program.cs, any line before builder.Build()
         *   builder.Services.AddDbContext<DataContext>(options => 
         *       options.UseSqlServer(builder.Configuration.GetConnectionString("IntranetServerTemplateDataContext"), //get connection string
         *       x => x.MigrationsAssembly("IntranetServerTemplate.Core")) //point the migrations engine to IntranetServerTemplate.Core 
         *       );
         * 
         * 6) Run the following commands:
         *      If you're creating the database with your classes:
         *          dotnet ef migrations add initial --project .\IntranetServerTemplate.Core --startup-project .\IntranetServerTemplate.Web
         *          dotnet ef database update --project .\IntranetServerTemplate.Core --startup-project .\IntranetServerTemplate.Web
         *
         * 7) To inject the datacontext into the service classes, add the following to Program.cs, any line before builder.build()
         *      builder.Services.AddScoped<DataContext>();
         */



        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }


    }
}
