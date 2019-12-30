using commissioning_assistance.Models.Commission;
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
    }
}
