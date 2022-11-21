using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustMgmt.Extentions;
using Microsoft.EntityFrameworkCore;

namespace CustMgmt.Entities
{
    public class CustMgmtDbContext: DbContext
    {
        public CustMgmtDbContext(DbContextOptions<CustMgmtDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Note> Notes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedData();
        }
    }
}
