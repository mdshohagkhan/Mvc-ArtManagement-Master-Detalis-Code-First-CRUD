using ArtMangementmvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArtMangementmvc.Data
{
	public class AppDbContext:DbContext
	{
        public AppDbContext() : base("AppDbContext") { }

        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<SaleDetaile> SaleDetailes { get; set; }

    }
}