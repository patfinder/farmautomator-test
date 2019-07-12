using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
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

            ConfigureOracle();

            var builder = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

            //Microsoft.EntityFrameworkCore.OracleDbContextOptionsExtensions.UseOracle(builder, "");

            //return builder.useora
            //    .UseOracle(@"User Id=blog;Password=<password>;Data Source=pdborcl;");
            //    .UseStartup<Startup>();

            return builder;
        }

        public static void ConfigureOracle()
        {
            // This sample demonstrates how to use ODP.NET Core Configuration API

            // Add connect descriptors and net service names entries.
            OracleConfiguration.OracleDataSources.Add("mbs_tns", "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)(SERVER=dedicated)))");
            //OracleConfiguration.OracleDataSources.Add("orcl", "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=<hostname or IP>)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=<service name>)(SERVER=dedicated)))");

            // Set default statement cache size to be used by all connections.
            OracleConfiguration.StatementCacheSize = 25;

            // Disable self tuning by default.
            OracleConfiguration.SelfTuning = false;

            // Bind all parameters by name.
            OracleConfiguration.BindByName = true;

            // Set default timeout to 60 seconds.
            OracleConfiguration.CommandTimeout = 60;

            // Set default fetch size as 1 MB.
            OracleConfiguration.FetchSize = 1024 * 1024;

            // Set tracing options
            OracleConfiguration.TraceOption = 1;
            OracleConfiguration.TraceFileLocation = @"D:\oracle_traces";
            // Uncomment below to generate trace files
            //OracleConfiguration.TraceLevel = 7;

            // Set network properties
            OracleConfiguration.SendBufferSize = 8192;
            OracleConfiguration.ReceiveBufferSize = 8192;
            OracleConfiguration.DisableOOB = true;

        }

    }
}
