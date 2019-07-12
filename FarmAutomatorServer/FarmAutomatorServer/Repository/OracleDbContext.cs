using FarmAutomatorServer.Repository.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAutomatorServer.Repository
{
    public class OracleDbContext : DbContext // IdentityDbContext
    {
        //public DbSet<User> Users { get; set; }

        public DbSet<WZ_ARTICLES> Articles { get; set; }

        public OracleDbContext()
        {

        }

        public OracleDbContext(DbContextOptions<OracleDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseOracle(@"User Id=mbs_db;Password=123456;Data Source=localhost:1521/XE;");
            optionsBuilder.UseOracle(@"User Id=mbs_db;Password=123456;Data Source=mbs_tns;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("mbs_db");
            modelBuilder.Entity<WZ_ARTICLES>().ToTable("wz_articles", "mbs_db");
        }
    }

    [Table("wz_articles", Schema = "mbs_db")]
    public class WZ_ARTICLES
    {
        public int ID { get; set; }

        public int STATUS { get; set; }
    }
}
