namespace ArtMangementmvc.Migrations
{
    using ArtMangementmvc.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArtMangementmvc.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ArtMangementmvc.Data.AppDbContext context)
        {
            var typelist = new List<CustomerType>()
            {

            new CustomerType{ CustomerTypeName="Regular"},
            new CustomerType{ CustomerTypeName="Premium"},
            new CustomerType{ CustomerTypeName="Exclusive"}
            };
            typelist.ForEach(s => context.CustomerTypes.AddOrUpdate(c => c.CustomerTypeName, s));
            context.SaveChanges();
        }
    }
}
