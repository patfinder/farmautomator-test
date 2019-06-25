using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
//using Microsoft.EntityFrameworkCore.OracleDbContextOptionsExtensions;

namespace FarmAutomatorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args){

            var builder = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

            //Microsoft.EntityFrameworkCore.OracleDbContextOptionsExtensions.UseOracle(builder, "");

            //return builder.useora
            //    .UseOracle(@"User Id=blog;Password=<password>;Data Source=pdborcl;");
            //    .UseStartup<Startup>();

            return builder;
        }
    }
}
