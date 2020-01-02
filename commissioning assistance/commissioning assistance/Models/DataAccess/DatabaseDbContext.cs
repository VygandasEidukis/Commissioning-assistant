using commissioning_assistance.Models.Commission;
using commissioning_assistance.Models.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models
{
    public class DatabaseDbContext : DbContext
    {
        public DbSet<InstagramCommission> Commissions { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CommissionsConfiguration());
        }
    }
}

