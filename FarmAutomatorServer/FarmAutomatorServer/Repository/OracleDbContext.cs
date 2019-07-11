using FarmAutomatorServer.Repository.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FarmAutomatorServer.Repository
{
    public class OracleDbContext : DbContext // IdentityDbContext
    {
        public DbSet<User> Users { get; set; }

        public OracleDbContext()
        {

        }

        public OracleDbContext(DbContextOptions<OracleDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"User Id=farmdb;Password=123456;Data Source=XE;");
        }
    }
}
